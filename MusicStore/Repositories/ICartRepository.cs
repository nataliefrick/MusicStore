using MusicStore.Models;
#nullable disable
namespace MusicStore.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int albumId, int qty);
        Task<int> RemoveItem(int albumId);
        Task<Cart> GetActiveCart();
        Task<int> GetCartItemCount(string userID = "");
        Task<Cart> GetCart(string userID);
        Task<bool> Checkout();

    }
}
