using AutoMapper;
using DTOs;
using Entities;
using Repository;
namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserService (IUserRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper=mapper;
        }
        public async Task<UserDTO> GetUserById(int id)
        {
            //return await _userRepository.GetUserById(id);
            User user = await _userRepository.GetUserById(id);
            UserDTO userDTO = _mapper.Map<User,UserDTO>(user);
            return userDTO;
        }
        public async Task<UserDTO> AddUser(User user)
        {
            if ((await _passwordService.CheckPasswordStrength(user.Password)).Strength <= 2)
                return null;

            
            User user1 = await _userRepository.AddUser(user);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user1);
            return userDTO;
        }
        public async Task UpdateUser(int id, User user)
        {
            await _userRepository.UpdateUser(id, user);

        }
        public async Task<UserDTO> Login(User user)
        {
            // return await _userRepository.login(user);
            User user3 = await _userRepository.Login(user);
            UserDTO userDTO = _mapper.Map<User,UserDTO>(user3);
            return userDTO;
        }
    }
}
