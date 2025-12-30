
namespace Tests
{


    using Xunit;
    using Entities;
    using Repository;
    using Microsoft.EntityFrameworkCore;
    using Tests;

    public class UserRepositoryIntegrationTests : IClassFixture<DbFixture>
    {
        private readonly WebApiShop216328971Context _context;
        private readonly UserRepository _repository;

        public UserRepositoryIntegrationTests(DbFixture fixture)
        {
            _context = fixture.Context;
            _repository = new UserRepository(_context);

            // ❌ לא סוגרים ולא עושים Dispose כאן
            // מבודד את ה־ChangeTracker כדי למנוע tracked duplicates
            _context.ChangeTracker.Clear();
        }
        public Task DisposeAsync()
        {
            // לא סוגרים את Context אם Fixture אחראי עליו
            // אפשר לנקות נתונים פה אם רוצים
            return Task.CompletedTask;
        }
        [Fact]
        public async Task RegisterAsync_ShouldSaveUserToRealDatabase()
        {
            var user = new User { UserEmail = "integration@test.com", Password = "123", FirstName = "Test", LastName = "User" };

            var result = await _repository.addUser(user);

            var userInDb = await _context.Users.FindAsync(result.Id);
            Assert.NotNull(userInDb);
            Assert.Equal("integration@test.com", userInDb.UserEmail);
        }

        [Fact]
        public async Task LoginAsync_ValidCredentials_ReturnsUserFromDb()
        {
            var user = new User { UserEmail = "login@integration.com", Password = "password123", FirstName = "A", LastName = "B" };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var result = await _repository.login(user);

            Assert.NotNull(result);
            Assert.Equal("login@integration.com", result.UserEmail);
        }
    }
}

