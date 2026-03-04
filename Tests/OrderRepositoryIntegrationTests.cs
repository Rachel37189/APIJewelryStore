using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Tests
{
    public class OrderRepositoryIntegrationTests : IClassFixture<DbFixture>
    {

        private readonly WebApiShop_215602996Context _context;
=======
using Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Tests
{
    

    public class OrderRepositoryIntegrationTests : IClassFixture<DbFixture>
    {
        private readonly WebApiShop216328971Context _context;
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        private readonly OrderRepository _repository;

        public OrderRepositoryIntegrationTests(DbFixture fixture)
        {
            _context = fixture.Context;
            _repository = new OrderRepository(_context);
            _context.ChangeTracker.Clear();
        }
<<<<<<< HEAD
        #region HappyTests
=======
        #region happy tests
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        [Fact]
        public async Task AddOrder_ShouldSaveOrderToDatabase()
        {
            // Arrange
<<<<<<< HEAD
            var user = new User { UserName = "test@user.com", Password = "456", FirstName = "Efrat", LastName = "Leibovitz" };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order { OrderSum = 100, UserId = user.Id };
=======
            var user = new User { UserEmail = "test@user.com", Password = "456", FirstName = "Efrat", LastName = "Leibovitz" };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order {  OrederSum = 100 ,UserId = user.Id};
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

            // Act
            var result = await _repository.addOrder(order);

            // Assert
            var orderInDb = await _context.Orders.FindAsync(result.OrderId);
            Assert.NotNull(orderInDb);
<<<<<<< HEAD
            Assert.Equal(100, orderInDb.OrderSum);
=======
            Assert.Equal(100, orderInDb.OrederSum);
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        }

        [Fact]
        public async Task GetOrderById_ShouldReturnCorrectOrder()
        {
            // Arrange
<<<<<<< HEAD
            var user = new User { UserName = "efrat@user.com", Password = "Ee123!@#WWW", FirstName = "A", LastName = "B" };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order { OrderSum = 200, UserId = user.Id }; // שים לב ל‑UserId
=======
            var user = new User { UserEmail = "efrat@user.com", Password = "Ee123!@#WWW", FirstName = "A", LastName = "B" };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order { OrederSum = 200, UserId = user.Id }; // שים לב ל‑UserId
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetOrderById(order.OrderId);

            // Assert
            Assert.NotNull(result);
<<<<<<< HEAD
            Assert.Equal(200, result.OrderSum);
        }
        #endregion
        #region UnHappyTests
=======
            Assert.Equal(200, result.OrederSum);
        }
        #endregion


        #region unhappy tests
        //שליפת הזמנה שלא קיימת
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        [Fact]
        public async Task GetOrderById_OrderDoesNotExist_ReturnsNull()
        {
            var result = await _repository.GetOrderById(9999);

            Assert.Null(result);
        }
<<<<<<< HEAD
=======
        //ניסיון להוסיף הזמנה עם משתמש לא קיים
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        [Fact]
        public async Task AddOrder_WithoutUser_ThrowsException()
        {
            var order = new Order
            {
<<<<<<< HEAD
                OrderSum = 100,
=======
                OrederSum = 100,
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
                UserId = 999 // לא קיים
            };

            await Assert.ThrowsAsync<DbUpdateException>(() =>
                _repository.addOrder(order));
        }
<<<<<<< HEAD
=======
 
       
        // ניסיון להוסיף הזמנה עם סכום שלילי
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        [Fact]
        public async Task AddOrder_NegativeSum_SavedButInvalidBusinessCase()
        {
            // Arrange
            var user = new User
            {
<<<<<<< HEAD
                UserName = "sum@test.com",
=======
                UserEmail = "sum@test.com",
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
                Password = "123",
                FirstName = "A",
                LastName = "B"
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var order = new Order
            {
<<<<<<< HEAD
                OrderSum = -50,
=======
                OrederSum = -50,
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
                UserId = user.Id
            };

            // Act
            var result = await _repository.addOrder(order);

            // Assert
<<<<<<< HEAD
            Assert.True(result.OrderSum < 0);
            #endregion
        }
=======
            Assert.True(result.OrederSum < 0);
        }

        #endregion
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
    }
}
