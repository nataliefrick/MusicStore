using MusicStore.Models;
#nullable disable
namespace MusicStore.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<OrderDetail>> GetOrderDetails(int? id);
    }
}