using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class UserRepository : IUserRepository
    {
        WebApiShop216328971Context _shopContext;
        public UserRepository(WebApiShop216328971Context userRepository)
        {
            _shopContext = userRepository;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _shopContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> addUser(User user)
        {
            await _shopContext.Users.AddAsync(user);
            await _shopContext.SaveChangesAsync();

           // _shopContext.SaveChanges();
            return user;
        }

        public async Task<User?> updateUser(User user)
        {
            _shopContext.Users.Update(user);
            //_shopContext.SaveChanges();
            await _shopContext.SaveChangesAsync();
            return user;


        }
        public async Task<User> login(User user)
        {
             return await _shopContext.Users.FirstOrDefaultAsync(x => x.UserEmail == user.UserEmail && x.Password == user.Password);     

        }
    }
}
