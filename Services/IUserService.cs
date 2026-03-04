//<<<<<<< HEAD
//﻿using Entities;
//using DTOs;
//=======
//﻿using DTOs;
//using Entities;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Services
//{
//    public interface IUserService
//    {
//<<<<<<< HEAD
//        Task<UserDTO> AddUser(User user);
//        Task<UserDTO> GetUserById(int id);
//        Task<UserDTO> Login(User user);
//        Task UpdateUser(int id, User user);
//=======
//        Task<UserDto> addUser(User user);
//        Task<UserDto> GetUserById(int id);
//        Task<UserDto> login(User user);
//        Task<UserDto> updateUser(int id, UserDto userDto);

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}


using DTOs;
using Entities;

public interface IUserService
{
    Task<UserDTO?> GetUserById(int id);
    Task<UserDTO?> AddUser(User user);
    Task<UserDTO?> UpdateUser(int id, UserDTO userDto);
    Task<UserDTO?> Login(User user);
}