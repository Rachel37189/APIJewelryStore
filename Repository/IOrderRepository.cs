using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<bool> UpdateOrderStatus(int orderId, int newStatus);

        Task<List<Order>> GetAllOrders();
    }
}