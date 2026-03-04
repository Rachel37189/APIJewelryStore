<<<<<<< HEAD
﻿using Xunit;
using Entities;
using Repository;
using Microsoft.EntityFrameworkCore;
namespace Tests {

    public class UserRepositoryIntegrationTests : IClassFixture<DbFixture>
    {
        private readonly WebApiShop_215602996Context _context;
=======
﻿
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
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        private readonly UserRepository _repository;

        public UserRepositoryIntegrationTests(DbFixture fixture)
        {
            _context = fixture.Context;
            _repository = new UserRepository(_context);

            // ❌ לא סוגרים ולא עושים Dispose כאן
            // מבודד את ה־ChangeTracker כדי למנוע tracked duplicates
            _context.ChangeTracker.Clear();
        }
<<<<<<< HEAD
=======
        public Task DisposeAsync()
        {
            // לא סוגרים את Context אם Fixture אחראי עליו
            // אפשר לנקות נתונים פה אם רוצים
            return Task.CompletedTask;
        }

>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        #region HappyTests
        [Fact]
        public async Task RegisterAsync_ShouldSaveUserToRealDatabase()
        {
<<<<<<< HEAD
            var user = new User { UserName = "integration@test.com", Password = "123", FirstName = "Test", LastName = "User" };
=======
            var user = new User { UserEmail = "integration@test.com", Password = "123", FirstName = "Test", LastName = "User" };
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

            var result = await _repository.addUser(user);

            var userInDb = await _context.Users.FindAsync(result.Id);
            Assert.NotNull(userInDb);
<<<<<<< HEAD
            Assert.Equal("integration@test.com", userInDb.UserName);
=======
            Assert.Equal("integration@test.com", userInDb.UserEmail);
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        }

        [Fact]
        public async Task LoginAsync_ValidCredentials_ReturnsUserFromDb()
        {
<<<<<<< HEAD
            var user = new User { UserName = "login@integration.com", Password = "password123", FirstName = "A", LastName = "B" };
=======
            var user = new User { UserEmail = "login@integration.com", Password = "password123", FirstName = "A", LastName = "B" };
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var result = await _repository.login(user);

            Assert.NotNull(result);
<<<<<<< HEAD
            Assert.Equal("login@integration.com", result.UserName);
        }
        #endregion
        #region UnHappyTests
=======
            Assert.Equal("login@integration.com", result.UserEmail);
        }
        #endregion


        #region unHappy Tests
        // כניסה עם סיסמה שגויה
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        [Fact]
        public async Task LoginAsync_WrongPassword_ReturnsNull()
        {
            var user = new User
            {
<<<<<<< HEAD
                UserName = "fail@test.com",
=======
                UserEmail = "fail@test.com",
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
                Password = "123",
                FirstName = "A",
                LastName = "B"
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            var loginAttempt = new User
            {
<<<<<<< HEAD
                UserName = "fail@test.com",
=======
                UserEmail = "fail@test.com",
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
                Password = "wrong"
            };

            var result = await _repository.login(loginAttempt);

            Assert.Null(result);
        }
<<<<<<< HEAD
        [Fact]
        public async Task RegisterAsync_DuplicateEmail_ThrowsException()
        {
            var user1 = new User { UserName = "dup@test.com", Password = "123" };
            var user2 = new User { UserName = "dup@test.com", Password = "456" };
=======
        //רישום משתמש עם אימייל שכבר קיים
        [Fact]
        //לא עובר כי אין דרישת ייחודיות במייל בטבלה

        public async Task RegisterAsync_DuplicateEmail_ThrowsException()
        {
            var user1 = new User { UserEmail = "dup@test.com", Password = "123" };
            var user2 = new User { UserEmail = "dup@test.com", Password = "456" };
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

            await _repository.addUser(user1);

            await Assert.ThrowsAsync<DbUpdateException>(() =>
                _repository.addUser(user2));
        }
<<<<<<< HEAD


        #endregion

    } 
}
=======
        // כניסה עם אימייל שלא קיים
        [Fact]
        public async Task Login_EmailNotExists_ReturnsNull()
        {
            // Arrange
            var user = new User
            {
                UserEmail = "notexist@test.com",
                Password = "123"
            };

            // Act
            var result = await _repository.login(user);

            // Assert
            Assert.Null(result);
        }
        
        

        #endregion
    }
}

>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
