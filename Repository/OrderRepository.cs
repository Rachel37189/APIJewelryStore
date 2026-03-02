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

        public async Task<bool> UpdateOrderStatus(int orderId, int newStatus)
        {
            var order = await _JewelryStore.Orders.FindAsync(orderId);
            if (order == null) return false;

            order.Status = newStatus;
            await _JewelryStore.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _JewelryStore.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await _JewelryStore.Orders
                .Include(o => o.OrderItems) // טעינת פריטי ההזמנה
                .ThenInclude(oi => oi.Product) // טעינת פרטי המוצר (בשביל השם שלו)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

    }
}
