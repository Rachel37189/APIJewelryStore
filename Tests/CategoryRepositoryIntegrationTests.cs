using Entities;
using Repository;

using Xunit;
using Repository;
using Entities;

namespace Tests
{
    // שימוש ב-Fixture
    public class CategoryRepositoryIntegrationTests : IClassFixture<DbFixture>
    {
        private readonly WebApiShop216328971Context _context;
        private readonly CategoryRepository _repository;

        public CategoryRepositoryIntegrationTests(DbFixture fixture)
        {
            _context = fixture.Context;
            _repository = new CategoryRepository(_context);

            // Clear ChangeTracker כדי למנוע tracked duplicates
            _context.ChangeTracker.Clear();
        }
        #region HappyTests
        [Fact]
        public async Task GetCategories_ShouldReturnAllCategories()
        {
            // Arrange - אפשר להוסיף קטגוריות זמניות ל-DB
            var cat = new Category { CategoryName = "TestCat" };
            await _context.Categories.AddAsync(cat);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, c => c.CategoryName == "TestCat");
        }
        #endregion

        #region UnhappyTests
        [Fact]
        public async Task GetCategories_WhenEmpty_ReturnsEmptyList()
        {
            var result = await _repository.GetCategories();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        #endregion
    }



}
