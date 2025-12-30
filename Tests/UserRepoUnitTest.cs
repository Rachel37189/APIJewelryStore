using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;

namespace Tests
{
    public class UserRepoUnitTest : TestBase
    {
        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsUser()
        {
            // Arrange
            var users = new List<User> { new User { Id = 1, UserEmail = "test@test.com" } };
            var mockContext = new Mock<WebApiShop216328971Context>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var repo = new UserRepository(mockContext.Object);

            // Act
            var result = await repo.GetUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }



        [Fact]
        public async Task RegisterAsync_ValidUser_ReturnsAddedUser()
        {
            // Arrange
            var mockContext = new Mock<WebApiShop216328971Context>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User>());
            var repo = new UserRepository(mockContext.Object);
            var newUser = new User { UserEmail = "new@test.com", FirstName = "A", LastName = "B", Password = "Ee123!@#WWW" };

            // Act
            var result = await repo.addUser(newUser);

            // Assert
            Assert.Equal("new@test.com", result.UserEmail);
            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_CorrectCredentials_ReturnsUser()
        {
            // Arrange
            var user = new User { UserEmail = "u@u.com", Password = "123" };
            var users = new List<User> {user};
            var mockContext = new Mock<WebApiShop216328971Context>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var repo = new UserRepository(mockContext.Object);

            // Act
            var result = await repo.login(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("u@u.com", result.UserEmail);
        }
        [Fact]
        public async Task login_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var users = new List<User> { new User { UserEmail = "real@test.com", Password = "1234" } };
            var mockContext = GetMockContext<WebApiShop216328971Context, User>(users, c => c.Users);

            var repo = new UserRepository(mockContext.Object);

            // Act
            var result = await repo.login(new User { UserEmail = "fake@test.com", Password = "0000" });

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task UpdateAsync_ValidUpdate_ReturnsUpdatedUser()
        {
            // Arrange
            var user = new User {Id = 1, FirstName = "OldName", UserEmail = "u@u.com" };
            var mockContext = new Mock<WebApiShop216328971Context>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User> { user });
            var repo = new UserRepository(mockContext.Object);

            // Act
            user.FirstName = "NewName";
            var result = await repo.updateUser(user);

            // Assert
            Assert.Equal("NewName", result.FirstName);
            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

    
    }
}
