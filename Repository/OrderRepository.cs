using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        JewelryStoreContext _JewelryStore;
        public OrderRepository(JewelryStoreContext context)
        {
            _JewelryStore = context;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _JewelryStore.Orders.FirstOrDefaultAsync(o => o.OrderId== id);
        }

       
        public async Task<Order> addOrder(Order? order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null");

            await _JewelryStore.Orders.AddAsync(order);
            await _JewelryStore.SaveChangesAsync();
            return order;
        }

    }
}
