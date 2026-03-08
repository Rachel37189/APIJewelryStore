

using DTOs;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrders();
    Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId);
    Task<OrderDTO?> GetOrderById(int id);
    Task<bool> UpdateStatus(int id, int status);
    Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto);
    Task<bool> MarkAsDelivered(int id);

}