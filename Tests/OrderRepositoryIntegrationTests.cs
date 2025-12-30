using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;
namespace Tests
{
    

    public class OrderRepositoryIntegrationTests : IClassFixture<DbFixture>
    {
        private readonly WebApiShop216328971Context _context;
        private readonly OrderRepository _repository;

        public OrderRepositoryIntegrationTests(DbFixture fixture)
        {
            _context = fixture.Context;
            _repository = new OrderRepository(_context);
            _context.ChangeTracker.Clear();
        }

        [Fact]
        public async Task AddOrder_ShouldSaveOrderToDatabase()
        {
            // Arrange
            var user = new User { UserEmail = "test@user.com", Password = "456", FirstName = "Efrat", LastName = "Leibovitz" };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order { /* מלאי שדות לפי Entity */ OrederSum = 100 ,UserId = user.Id};

            // Act
            var result = await _repository.addOrder(order);

            // Assert
            var orderInDb = await _context.Orders.FindAsync(result.OrderId);
            Assert.NotNull(orderInDb);
            Assert.Equal(100, orderInDb.OrederSum);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturnCorrectOrder()
        {
            // Arrange
            var user = new User { UserEmail = "efrat@user.com", Password = "Ee123!@#WWW", FirstName = "A", LastName = "B" };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order { OrederSum = 200, UserId = user.Id }; // שים לב ל‑UserId
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetOrderById(order.OrderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.OrederSum);
        }
    }
}
