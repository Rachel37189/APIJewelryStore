using DTOs;
using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<UserDto> addUser(User user);
        Task<UserDto> GetUserById(int id);
        Task<UserDto> login(User user);
        Task<UserDto> updateUser(int id, UserDto userDto);

    }
}