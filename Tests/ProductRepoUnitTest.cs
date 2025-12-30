using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace Tests
{
    public class ProductRepoUnitTest : TestBase
    {
        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Cake" },
                new Product { ProductId = 2, ProductName = "Cookie" }
            };

            var mockContext =
                GetMockContext<WebApiShop216328971Context, Product>(products, c => c.Products);

            var repo = new ProductRepository(mockContext.Object);

            // Act
            var result = await repo.GetProducts(null, null, null, null, null);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Cake", result[0].ProductName);
        }
    }
}

