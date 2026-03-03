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
        //public void updateUser(int id, User user)
        //{
        //    _userRepository.updateUser(user);

        //}

        //public async Task<UserUpdateDto> updateUser(int id, UserUpdateDto userDto)
        //{
        //    // המרה מ-DTO ל-Entity
        //    User userEntity = _mapper.Map<User>(userDto);
        //    userEntity.UserId = id; // וידוא ה-ID מהנתיב

        //    User updatedUser = await _userRepository.updateUser(userEntity);

        //    // החזרה של הנתונים המעודכנים כ-DTO
        //    return _mapper.Map<UserUpdateDto>(updatedUser);
        //}

        public async Task<UserDto> updateUser(int id, UserDto userDto)
        {
            // 1. שליפת המשתמש הקיים מה-DB (כדי לא לאבד את האימייל והסיסמה)
            User existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null) return null;

            // 2. עדכון רק של השדות המותרים
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Phone = userDto.Phone;
            existingUser.City = userDto.City;
            existingUser.Street = userDto.Street;
            existingUser.HouseNumber = userDto.HouseNumber;

            // 3. שמירה דרך ה-Repository
            User updatedUser = await _userRepository.updateUser(existingUser);

            // 4. החזרה כ-DTO
            return _mapper.Map<UserDto>(updatedUser);
        }
        public async Task<UserDto> login(User user)
        {
            User user3= await _userRepository.login(user);
            UserDto userDto = _mapper.Map<UserDto>(user3);
            return userDto;
        }
    }
}
