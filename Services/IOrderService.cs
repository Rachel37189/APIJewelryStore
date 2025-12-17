using DTOs;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<OrderDto> addOrder(Order order);
        Task<OrderDto> GetOrderById(int id);
    }
}