using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Reflection.Metadata;
using System.Text.Json;
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
            return await _jewelryStoreContext.Users.FirstOrDefaultAsync(u=>u.UserId==id);
        }
        public async Task<User> AddUser(User? user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            await _jewelryStoreContext.Users.AddAsync(user);
            await _jewelryStoreContext.SaveChangesAsync();
            return user;
        }
       
        public async Task UpdateUser(int id, User user)
        {
            _jewelryStoreContext.Users.Update(user);
            //_webApiShopContext.Users.Update(user);
            await _jewelryStoreContext.SaveChangesAsync();
        }
        public async Task<User> Login(User user)
        {
            return await _jewelryStoreContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}
