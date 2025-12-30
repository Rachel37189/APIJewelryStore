using AutoMapper;
using DTOs;
using Entities;
using FluentNHibernate.Automapping;
using Repository;
namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IPasswordService _passwordService;
        //AutoMapper _mapper;
        IMapper _mapper;


        public UserService (IUserRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;

        }
        public async Task<UserDto> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public async Task<UserDto> addUser(User user)
        {
            if (_passwordService.Level(user.Password).Strength <= 2)
                return null;
            User user1 = await _userRepository.addUser(user);
            UserDto userDto = _mapper.Map<UserDto>(user1);
            return userDto;
        }
        public void updateUser(int id, User user)
        {
            _userRepository.updateUser(user);

        }
        public async Task<UserDto> login(User user)
        {
            User user3= await _userRepository.login(user);
            UserDto userDto = _mapper.Map<UserDto>(user3);
            return userDto;
        }
    }
}
