using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        WebApiShop216328971Context _shopContext;
        public OrderRepository(WebApiShop216328971Context userRepository)
        {
            _shopContext = userRepository;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _shopContext.Orders.FindAsync(id);
        }

        public async Task<Order> addOrder(Order order)
        {
            await _shopContext.Orders.AddAsync(order);
            _shopContext.SaveChanges();
            return order;
        }


    }
}
