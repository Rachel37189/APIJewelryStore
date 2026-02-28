using Entities;
using DTOs;
namespace Services
{
    public interface IUserService
    {
        Task<UserDTO> AddUser(User user);
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> Login(User user);
        Task UpdateUser(int id, User user);
    }
}