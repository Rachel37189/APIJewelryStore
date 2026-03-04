//using AutoMapper;
//using DTOs;
//using Entities;
//<<<<<<< HEAD
//=======
//using FluentNHibernate.Automapping;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//using Repository;
//namespace Services
//{
//    public class UserService : IUserService
//    {
//<<<<<<< HEAD
//        private readonly IUserRepository _userRepository;
//        private readonly IPasswordService _passwordService;
//        private readonly IMapper _mapper;
//=======
//        IUserRepository _userRepository;
//        IPasswordService _passwordService;
//        //AutoMapper _mapper;
//        IMapper _mapper;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//        public UserService (IUserRepository userRepository, IPasswordService passwordService, IMapper mapper)
//        {
//            _userRepository = userRepository;
//            _passwordService = passwordService;
//<<<<<<< HEAD
//            _mapper=mapper;
//        }
//        public async Task<UserDTO> GetUserById(int id)
//        {
//            //return await _userRepository.GetUserById(id);
//            User user = await _userRepository.GetUserById(id);
//            UserDTO userDTO = _mapper.Map<User,UserDTO>(user);
//            return userDTO;
//        }
//        public async Task<UserDTO> AddUser(User user)
//        {
//            if ((await _passwordService.CheckPasswordStrength(user.Password)).Strength <= 2)
//                return null;


//            User user1 = await _userRepository.AddUser(user);
//            UserDTO userDTO = _mapper.Map<User, UserDTO>(user1);
//            return userDTO;
//        }
//        public async Task UpdateUser(int id, User user)
//        {
//            await _userRepository.UpdateUser(id, user);

//        }
//        public async Task<UserDTO> Login(User user)
//        {
//            // return await _userRepository.login(user);
//            User user3 = await _userRepository.Login(user);
//            UserDTO userDTO = _mapper.Map<User,UserDTO>(user3);
//            return userDTO;
//=======
//            _mapper = mapper;

//        }
//        public async Task<UserDto> GetUserById(int id)
//        {
//            User user = await _userRepository.GetUserById(id);
//            UserDto userDto = _mapper.Map<UserDto>(user);
//            return userDto;
//        }
//        public async Task<UserDto> addUser(User user)
//        {
//            if (_passwordService.Level(user.Password).Strength <= 2)
//                return null;
//            User user1 = await _userRepository.addUser(user);
//            UserDto userDto = _mapper.Map<UserDto>(user1);
//            return userDto;
//        }
//        //public void updateUser(int id, User user)
//        //{
//        //    _userRepository.updateUser(user);

//        //}

//        //public async Task<UserUpdateDto> updateUser(int id, UserUpdateDto userDto)
//        //{
//        //    // המרה מ-DTO ל-Entity
//        //    User userEntity = _mapper.Map<User>(userDto);
//        //    userEntity.UserId = id; // וידוא ה-ID מהנתיב

//        //    User updatedUser = await _userRepository.updateUser(userEntity);

//        //    // החזרה של הנתונים המעודכנים כ-DTO
//        //    return _mapper.Map<UserUpdateDto>(updatedUser);
//        //}

//        public async Task<UserDto> updateUser(int id, UserDto userDto)
//        {
//            // 1. שליפת המשתמש הקיים מה-DB (כדי לא לאבד את האימייל והסיסמה)
//            User existingUser = await _userRepository.GetUserById(id);
//            if (existingUser == null) return null;

//            // 2. עדכון רק של השדות המותרים
//            existingUser.FirstName = userDto.FirstName;
//            existingUser.LastName = userDto.LastName;
//            existingUser.Phone = userDto.Phone;
//            existingUser.City = userDto.City;
//            existingUser.Street = userDto.Street;
//            existingUser.HouseNumber = userDto.HouseNumber;

//            // 3. שמירה דרך ה-Repository
//            User updatedUser = await _userRepository.updateUser(existingUser);

//            // 4. החזרה כ-DTO
//            return _mapper.Map<UserDto>(updatedUser);
//        }
//        public async Task<UserDto> login(User user)
//        {
//            User user3= await _userRepository.login(user);
//            UserDto userDto = _mapper.Map<UserDto>(user3);
//            return userDto;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        }
//    }
//}


using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> AddUser(User user)
        {
            // שימוש ב-PasswordService המעודכן (סינכרוני ומחזיר int)
            if (_passwordService.CheckPasswordStrength(user.Password) <= 2)
                return null;

            User user1 = await _userRepository.AddUser(user);
            return _mapper.Map<UserDTO>(user1);
        }

        public async Task<UserDTO?> UpdateUser(int id, UserDTO userDto)
        {
            // 1. שליפת המשתמש הקיים מה-DB כדי לשמור על שדות שלא ב-DTO (כמו סיסמה)
            User existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null) return null;

            // 2. עדכון השדות מה-DTO לישות הקיימת
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Phone = userDto.Phone;
            existingUser.City = userDto.City;
            existingUser.Street = userDto.Street;
            existingUser.HouseNumber = userDto.HouseNumber;
            // אימייל בדרך כלל לא מעדכנים כאן, אבל אם צריך: existingUser.Email = userDto.Email;

            // 3. שמירה
            User updatedUser = await _userRepository.UpdateUser(existingUser);

            return _mapper.Map<UserDTO>(updatedUser);
        }

        public async Task<UserDTO?> Login(User user)
        {
            User loggedInUser = await _userRepository.Login(user);
            return _mapper.Map<UserDTO>(loggedInUser);
        }
    }
}
