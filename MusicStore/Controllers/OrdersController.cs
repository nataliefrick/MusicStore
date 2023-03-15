using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _context;

        public OrdersController(IOrdersRepository orderRepo)
        {
            _context = orderRepo;
        }
        public async Task<IActionResult> Orders()
        {
            var orders = await _context.GetOrders();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var orderDetails = await _context.GetOrderDetails(id);
            return View(orderDetails);
        }

    }
}
