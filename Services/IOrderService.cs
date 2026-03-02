using Entities;
using DTOs;
namespace Services
{
    public interface IOrderService
    {
        Task<OrderDTO> addOrder(OrderDTO order);
        Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto);
        Task<OrderDTO> GetOrderById(int id);
    }
}