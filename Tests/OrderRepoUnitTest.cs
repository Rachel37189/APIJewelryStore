using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;
using Moq;

namespace Tests
{
    public class OrderRepoUnitTest : TestBase
    {
        [Fact]
        public async Task GetOrderById_ExistingId_ReturnsOrder()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { OrderId = 1, UserId = 3 }
            };

            var mockContext =
                GetMockContext<WebApiShop216328971Context, Order>(orders, c => c.Orders);

            var repo = new OrderRepository(mockContext.Object);

            // Act
            var result = await repo.GetOrderById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.OrderId);
        }

        [Fact]
        public async Task AddOrder_ValidOrder_ReturnsOrder()
        {
            // Arrange
            var orders = new List<Order>();

            var mockContext =
                GetMockContext<WebApiShop216328971Context, Order>(orders, c => c.Orders);

            var repo = new OrderRepository(mockContext.Object);

            var order = new Order { OrderId = 1, UserId = 3 };

            // Act
            var result = await repo.addOrder(order);

            // Assert
            Assert.NotNull(result);

            Assert.Equal(1, result.OrderId);
        }
    }
       
    }
