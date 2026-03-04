//using Entities;

//namespace Repository
//{
//    public interface IUserRepository
//    {
//<<<<<<< HEAD
//        Task<User> AddUser(User user);
//        Task<User> GetUserById(int id);
//        Task<User> Login(User user);
//        Task UpdateUser(int id, User user);
//=======
//        Task<User> addUser(User user);
//        Task<User> GetUserById(int id);
//        Task<User> login(User user);
//        Task<User?> updateUser(User user);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}

using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);

        Task<User?> GetUserById(int id);

        Task<User?> Login(User user);

        Task<User?> UpdateUser(User user);
    }
}