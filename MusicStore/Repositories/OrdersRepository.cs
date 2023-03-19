using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
#nullable disable
namespace MusicStore.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public OrdersRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
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

        // Get All orders for specific userID
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new Exception("User not logged in");

            var orders = await _context.Orders
                .Include(x => x.OrdStat)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Album)
                .ThenInclude(x => x.Genre)
                .Where(a => a.UserId==userId)
                .ToListAsync();

            return orders;
        }

        // GET: Order Details for specific orderID
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails(int? id)
        {

            var orderDetails = await _context.OrderDetails
                .Include(x => x.Order)
                .ThenInclude(x => x.OrderDetails)
                .ThenInclude(x => x.Album)
                .ThenInclude(x => x.Genre)
                .Where(c => c.OrderId == id).ToListAsync(); 

            //if (orderDetails == null)
            //    throw new Exception("Invalid Order");

            return orderDetails;

        }


    }
}
