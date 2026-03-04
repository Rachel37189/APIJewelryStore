//using Entities;

//namespace Repository
//{
//    public interface IOrderRepository
//    {
//        Task<Order> addOrder(Order order);
//        Task<Order> GetOrderById(int id);
//<<<<<<< HEAD
//        Task<bool> UserExistsAsync(int userId);
//        Task<Dictionary<int, double>> GetProductPricesAsync(IEnumerable<int> productIds);
//        Task<Order> AddOrderWithItemsAsync(Order order);
//=======
//        Task<bool> UpdateOrderStatus(int orderId, int newStatus);

//        Task<List<Order>> GetAllOrders();

//        Task<List<Order>> GetOrdersByUserId(int userId);


//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}


using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);

        Task<Order?> GetOrderById(int id);

        Task<List<Order>> GetAllOrders();

        Task<List<Order>> GetOrdersByUserId(int userId);

        Task<bool> UpdateOrderStatus(int orderId, int newStatus);

        Task<bool> UserExistsAsync(int userId);

        Task<Dictionary<int, double>> GetProductPricesAsync(IEnumerable<int> productIds);

        Task<Order> AddOrderWithItemsAsync(Order order);
    }
}