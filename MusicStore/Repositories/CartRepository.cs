using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
#nullable disable
namespace MusicStore.Repositories
{
    public class CartRepository : ICartRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CartRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get User ID of customer
        private string GetUserId()
        {
            var userPrinciple = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(userPrinciple);
            return userId;
        }

        // Check to see if user has an open shopping cart
        public async Task<Cart> GetCart(string userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            //return cart != null ? true : false;            
            //if cart is not null, return true otherwise return false
            return cart;
        }

        // Add item to cart
        public async Task<int> AddItem(int albumId, int qty)
        {
            using var transaction = _context.Database.BeginTransaction();
            string userId = GetUserId();
            try
            {
                // if UserId is not found
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("Not logged in");


                var cart = await GetCart(userId);
                if (cart is null)
                {
                    // if cart is null, create new instance of Cart
                    cart = new Cart 
                    {
                        UserId = userId
                    };
                    
                    _context.Carts.Add(cart);
                }
                _context.SaveChanges();


                // shoppingcart details section
                var cartItem = _context.CartDetails.FirstOrDefault(a => a.CartId == cart.CartId && a.AlbumId == albumId);
                if (cartItem != null)
                {
                    // if item exists in cart increase quantity
                    cartItem.Quantity += qty;
                }
                else
                {
                    // if item does not exist create item
                    var album = _context.Albums.Find(albumId);
                    cartItem = new CartDetail
                    {
                        AlbumId = albumId,
                        CartId = cart.CartId,
                        Quantity = qty,
                        UnitPrice = album.Price
                    };
                    _context.CartDetails.Add(cartItem);
                }
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                
            }
            var nrItemsFound = await GetCartItemCount(userId);
            return nrItemsFound;
        }

        // Remove item (reduce quantity) of item in cart
        public async Task<int> RemoveItem(int albumId)
        {
            using var transaction = _context.Database.BeginTransaction();

            string userId = GetUserId();
            try
            {
                // if UserId is not found
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("Not logged in");

                // find cart of UserId
                var cart = await GetCart(userId);
                if (cart is null)
                throw new Exception("Shopping Cart is empty");
                _context.SaveChanges();


                // shoppingcart details section
                // find cart-item in cart
                var cartItem = _context.CartDetails.FirstOrDefault(a => a.CartId == cart.CartId && a.AlbumId == albumId);
                
                if (cartItem == null) //if item not found in cart
                    throw new Exception("Item not found");
                else if (cartItem.Quantity == 1) //delete item if quantity=1
                    _context.CartDetails.Remove(cartItem);
                else //reduce item by 1  
                    cartItem.Quantity = cartItem.Quantity - 1;

                _context.SaveChanges();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                
            }
            var nrItemsFound = await GetCartItemCount(userId);
            return nrItemsFound;

        }

        public async Task<Cart> GetActiveCart() 
        {
            var userId = GetUserId();
            if(userId == null)
               throw new Exception("Invalid User");

            // join Carts with items with album and genre
            var cart = await _context.Carts
                .Include(c => c.CartDetails)
                .ThenInclude(c => c.Album)
                .ThenInclude(c => c.Genre)
                .Where(c => c.UserId == userId).FirstOrDefaultAsync();

            return cart;
        }
        
        // get nr items in cart
        public async Task<int> GetCartItemCount(string userID = "")
        {
            if(!string.IsNullOrEmpty(userID)) { 
            var userId = GetUserId();
            }
            var result = await (from cart in _context.Carts
                              join cartDetail in _context.CartDetails
                              on cart.CartId equals cartDetail.CartId
                              select new             
                              { 
                                  cartDetail.CartDetailId 
                              }).ToListAsync();

            return result.Count;

        }

        public async Task<bool> Checkout()
        {
            using var transaction = _context.Database.BeginTransaction();
            try 
            {
                // move data from cartDetail to Order and OrderDetail then remove CartDetail
                var userId = GetUserId();

                // if UserId is not found
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("Not logged in");

                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Cart not found");

                var cartDetail = _context.CartDetails
                                .Where(a => a.CartId == cart.CartId).ToList();
                
                if(cartDetail.Count == 0) throw new Exception("Cart is empty");

                var order = new Order
                {
                    UserId = userId,
                    OrdStatId = 1 // pending
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach(var item in cartDetail)
                {
                    var orderDetail = new OrderDetail
                    {
                        AlbumId = item.AlbumId,
                        OrderId = order.OrderId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    _context.OrderDetails.Add(orderDetail);
                }
                _context.SaveChanges();

                // delete cartdetails from cart
                _context.CartDetails.RemoveRange(cartDetail);
                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
    }
}
