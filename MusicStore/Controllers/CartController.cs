using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private readonly ICartRepository _context;

        public CartController(ICartRepository cartRepo)
        {
            _context = cartRepo;
        }

        public async Task<IActionResult> AddItem(int albumId, int qty = 1, int redirect = 0)
        {
            var cartCount = await _context.AddItem(albumId, qty);
            if (redirect == 0) return Ok(cartCount);
            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> RemoveItem(int albumId)
        {
            await _context.RemoveItem(albumId);
            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> Cart()
        {
            var cart = await _context.GetActiveCart();
            return View(cart);
        }

        public async Task<IActionResult> GetCartCount()
        {
            var cartItem = await _context.GetCartItemCount();
            return Ok(cartItem);
        }

        public async Task<IActionResult> Checkout()
        {
            bool isCheckedOut = await _context.Checkout();
            
            if (!isCheckedOut) throw new Exception("Something went wrong with the server. Please try again.");
            return RedirectToAction("Orders", "Orders");
            
        }
    }
}
