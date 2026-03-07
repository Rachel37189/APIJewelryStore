
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly JewelryStoreContext _jewelryStoreContext;

        public OrderRepository(JewelryStoreContext jewelryStoreContext)
        {
            _jewelryStoreContext = jewelryStoreContext;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _jewelryStoreContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _jewelryStoreContext.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await _jewelryStoreContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<Order> AddOrder(Order? order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null");

            await _jewelryStoreContext.Orders.AddAsync(order);
            await _jewelryStoreContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrderStatus(int orderId, int newStatus)
        {
            var order = await _jewelryStoreContext.Orders.FindAsync(orderId);
            if (order == null) return false;

            order.Status = newStatus;
            await _jewelryStoreContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _jewelryStoreContext.Users.AnyAsync(u => u.UserId == userId);
        }

        public async Task<Dictionary<int, double>> GetProductPricesAsync(IEnumerable<int> productIds)
        {
            var ids = productIds.Distinct().ToList();
            var prices = await _jewelryStoreContext.Products
                .Where(p => ids.Contains(p.ProductId))
                .Select(p => new { p.ProductId, p.ProductPrice })
                .ToListAsync();

            return prices.ToDictionary(x => x.ProductId, x => x.ProductPrice);
        }

        public async Task<Order> AddOrderWithItemsAsync(Order order)
        {
            using var tx = await _jewelryStoreContext.Database.BeginTransactionAsync();
            try
            {
                await _jewelryStoreContext.Orders.AddAsync(order);

                foreach (var item in order.OrderItems)
                {
                    var stockItem = await _jewelryStoreContext.Sizes
                        .FirstOrDefaultAsync(ps => ps.ProductId == item.ProductId && ps.ProductSize == item.Size.ToString());

                    if (stockItem != null)
                    {
                        stockItem.Amount -= item.Quantity;
                        if (stockItem.Amount < 0)
                        {
                            throw new Exception("המלאי נגמר עבור פריט זה");
                        }
                    }
                }

                await _jewelryStoreContext.SaveChangesAsync();
                await tx.CommitAsync();
                return order;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}