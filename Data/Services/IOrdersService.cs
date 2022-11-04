using OnlineTickets.Models;

namespace OnlineTickets.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<Order>> GetOrderByUserIdAsync(string userId);
    }
}
