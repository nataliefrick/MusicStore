using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public class CartRepository
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
    
        //public async Task<bool> AddItem(int albumId, int qty)
        //{
        //    using var transaction = _context.Database.BeginTransaction();

        //    try { 
        //        string userId = GetUserId();
        //        // if UserId is not found
        //        if(string.IsNullOrEmpty(userId))
        //            return false;
            
            
        //        var cart = await GetCart(userId);
        //        if (cart is null)
        //        {
        //            cart = new Cart
        //            {
        //                UserId = userId
        //            };
        //            //If Cart is null, create a new shopping cart
        //            _context.Carts.Add(cart);
        //        }
        //        _context.SaveChanges();


        //        // shoppingcart details section
        //        var cartItem = _context.CartDetails.FirstOrDefault(a => a.CartId == cart.CartId && a.albumId == albumId);
        //        if (cartItem != null)
        //        {
        //            cartItem.Quantity += qty;
        //        }
        //        else
        //        {
        //            cartItem = new CartDetail
        //            {
        //                AlbumId = albumId,
        //                CartId = cart.CartId, 
        //                Quantity= qty
        //            };
        //            _context.CartDetails.Add(cartItem);
        //        }
        //        _context.SaveChanges();
        //        transaction.Commit();
        //        return true;
        //    } 
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }

   


        //}

        // Check to see if user has an open shopping cart
        private async Task<Cart> GetCart(string userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            //return cart != null ? true : false;            
            //if cart is not null, return true otherwise return false
            return cart;
        }

        // Get User ID of customer
        private string GetUserId()
        {
            var userPrinciple = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(userPrinciple);
            return userId;
        }
    }
}
