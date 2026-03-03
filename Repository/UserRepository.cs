using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class UserRepository : IUserRepository
    {
        JewelryStoreContext _JewelryStore;
        public UserRepository(JewelryStoreContext userRepository)
        {
            _JewelryStore = userRepository;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _JewelryStore.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User> addUser(User? user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            await _JewelryStore.Users.AddAsync(user);
            await _JewelryStore.SaveChangesAsync();
            return user;
        }


        //public async Task<User?> updateUser(User user)
        //{
        //    var existingUser = await _JewelryStore.Users
        //        .FirstOrDefaultAsync(u => u.UserId == user.UserId);

        //    if (existingUser == null)
        //        return null;

        //    existingUser.FirstName = user.FirstName;
        //    existingUser.LastName = user.LastName;
        //    existingUser.Email = user.Email;

        //    await _JewelryStore.SaveChangesAsync();
        //    return existingUser;
        //}

        public async Task<User?> updateUser(User user)
        {
            var existingUser = await _JewelryStore.Users
                .FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (existingUser == null) return null;

            // עדכון השדות הקיימים
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;

            // הוספת השדות החדשים שהיו חסרים:
            existingUser.Phone = user.Phone;
            existingUser.City = user.City;
            existingUser.Street = user.Street;
            existingUser.HouseNumber = user.HouseNumber;

            await _JewelryStore.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> login(User user)
        {
             return await _JewelryStore.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);     

        }
    }
}
