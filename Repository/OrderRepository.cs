using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Reflection.Metadata;
using System.Text.Json;
namespace Repository
{
    public class OrderRepository : IOrderRepository
    {

        public readonly JewelryStoreContext _jewelryStoreContext;
        public OrderRepository(JewelryStoreContext jewelryStoreContext)
        {
            _jewelryStoreContext = jewelryStoreContext;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _jewelryStoreContext.Orders.FirstOrDefaultAsync(o=>o.OrderId==id);
        }

        public async Task<Order> addOrder(Order? order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null");

            await _jewelryStoreContext.Orders.AddAsync(order);
            await _jewelryStoreContext.SaveChangesAsync();
            return order;
        }

    }
}
