//<<<<<<< HEAD
//﻿using Entities;
//using Microsoft.EntityFrameworkCore;
//using Repository;
//using System.Reflection.Metadata;
//using System.Text.Json;
//=======
//﻿using System.Reflection.Metadata;
//using System.Text.Json;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Repository
//{
//    public class UserRepository : IUserRepository
//    {
//<<<<<<< HEAD

//        private readonly JewelryStoreContext _jewelryStoreContext;
//        public UserRepository(JewelryStoreContext jewelryStoreContext)
//        {
//            _jewelryStoreContext = jewelryStoreContext;
//        }
//        public async Task<User> GetUserById(int id)
//        {
//            return await _jewelryStoreContext.Users.FirstOrDefaultAsync(u=>u.UserId==id);
//        }
//        public async Task<User> AddUser(User? user)
//=======
//        JewelryStoreContext _JewelryStore;
//        public UserRepository(JewelryStoreContext userRepository)
//        {
//            _JewelryStore = userRepository;
//        }
//        public async Task<User> GetUserById(int id)
//        {
//            return await _JewelryStore.Users.FirstOrDefaultAsync(u => u.UserId == id);
//        }
//        public async Task<User> addUser(User? user)
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        {
//            if (user == null)
//                throw new ArgumentNullException(nameof(user), "User cannot be null");

//<<<<<<< HEAD
//            await _jewelryStoreContext.Users.AddAsync(user);
//            await _jewelryStoreContext.SaveChangesAsync();
//            return user;
//        }

//        public async Task UpdateUser(int id, User user)
//        {
//            _jewelryStoreContext.Users.Update(user);
//            //_webApiShopContext.Users.Update(user);
//            await _jewelryStoreContext.SaveChangesAsync();
//        }
//        public async Task<User> Login(User user)
//        {
//            return await _jewelryStoreContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
//=======
//            await _JewelryStore.Users.AddAsync(user);
//            await _JewelryStore.SaveChangesAsync();
//            return user;
//        }


//        //public async Task<User?> updateUser(User user)
//        //{
//        //    var existingUser = await _JewelryStore.Users
//        //        .FirstOrDefaultAsync(u => u.UserId == user.UserId);

//        //    if (existingUser == null)
//        //        return null;

//        //    existingUser.FirstName = user.FirstName;
//        //    existingUser.LastName = user.LastName;
//        //    existingUser.Email = user.Email;

//        //    await _JewelryStore.SaveChangesAsync();
//        //    return existingUser;
//        //}

//        public async Task<User?> updateUser(User user)
//        {
//            var existingUser = await _JewelryStore.Users
//                .FirstOrDefaultAsync(u => u.UserId == user.UserId);

//            if (existingUser == null) return null;

//            // עדכון השדות הקיימים
//            existingUser.FirstName = user.FirstName;
//            existingUser.LastName = user.LastName;
//            existingUser.Email = user.Email;

//            // הוספת השדות החדשים שהיו חסרים:
//            existingUser.Phone = user.Phone;
//            existingUser.City = user.City;
//            existingUser.Street = user.Street;
//            existingUser.HouseNumber = user.HouseNumber;

//            await _JewelryStore.SaveChangesAsync();
//            return existingUser;
//        }

//        public async Task<User> login(User user)
//        {
//             return await _JewelryStore.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);     

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        }
//    }
//}

using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly JewelryStoreContext _jewelryStoreContext;

        public UserRepository(JewelryStoreContext jewelryStoreContext)
        {
            _jewelryStoreContext = jewelryStoreContext;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _jewelryStoreContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> AddUser(User? user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            await _jewelryStoreContext.Users.AddAsync(user);
            await _jewelryStoreContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var existingUser = await _jewelryStoreContext.Users
                .FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (existingUser == null) return null;

            // עדכון השדות
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.City = user.City;
            existingUser.Street = user.Street;
            existingUser.HouseNumber = user.HouseNumber;
            existingUser.Password = user.Password; // כדאי לוודא שגם הסיסמה מתעדכנת אם צריך

            await _jewelryStoreContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> Login(User user)
        {
            return await _jewelryStoreContext.Users
                .FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}
