using DTOs;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<OrderDto> addOrder(Order order);
        Task<OrderDto> GetOrderById(int id);

        Task<bool> UpdateStatus(int id, int status);
        Task<IEnumerable<OrderDto>> GetAllOrders();

        Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId);
    }
}