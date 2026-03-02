using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<bool> UserExistsAsync(int userId);
        Task<Dictionary<int, double>> GetProductPricesAsync(IEnumerable<int> productIds);
        Task<Order> AddOrderWithItemsAsync(Order order);
    }
}