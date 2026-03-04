//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using static WebApiShop.Controllers.UsersController;
//using Entities;
//using Repository;
//using Services;
//using DTOs;

//<<<<<<< HEAD
//=======

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApiShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly ILogger<UsersController> _logger;
//<<<<<<< HEAD
//        private readonly IUserService _userService;
//        public UsersController(ILogger<UsersController> logger, IUserService userService)
//        {
//            _logger = logger;
//            _userService = userService;
//        }



//        // GET api/<UsersController>/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDTO>> Get(int id)
//        {

//            UserDTO user= await _userService.GetUserById(id);
//=======
//        IUserService _userService ;
//        public UsersController(IUserService userService, ILogger<UsersController> logger)
//        {
//            _userService = userService;
//            _logger = logger;

//        }

//        // GET: api/<UsersController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<UsersController>/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDto>> Get(int id)
//        {

//            UserDto user= await _userService.GetUserById(id);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//            if (user == null)
//                   return NoContent();
//            return Ok(user);
//        }
//        // POST api/<UsersController>
//        [HttpPost]
//<<<<<<< HEAD
//        public async Task<ActionResult<UserDTO>> Post([FromBody] User user)
//        {
//           UserDTO _user = await _userService.AddUser(user);
//=======
//        public async Task<ActionResult<UserDto>> Post([FromBody] User user)
//        {
//            UserDto _user =await _userService.addUser(user);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//            if (_user == null)
//            {
//                return BadRequest("סיסמא חלשה - נסה סיסמא שונה");
//            }
//            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);

//        }

//<<<<<<< HEAD
//        [HttpPost("Login")]
//        public async Task<ActionResult<UserDTO>> Login([FromBody] User user)
//        {
//           UserDTO _user = await _userService.Login(user);
//            if (_user == null) {
//                _logger.LogInformation("Login failed: UserName={UserName},Password={Password}", user.Email,user.Password);
//                return NoContent() ;
//            }
//            _logger.LogInformation("Login success: UserName={UserName},Password={Password}",
//             user.Email, user.Password);
//            return Ok(_user);

//        }
//        // PUT api/<UsersController>/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put(int id, [FromBody] User user)
//        {
//            await _userService.UpdateUser(id, user);
//            return Ok(user);
//=======
//        //[HttpPost("Login")]
//        //public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData)
//        //{
//        //    UserDto _user = await _userService.login(user);
//        //    if (_user == null)
//        //    {
//        //        _logger.LogInformation("Login failed: UserName={UserEmail},FirstName={FirstName},LastName={LastName}", user?.Email, user?.FirstName, user?.LastName);
//        //        return NoContent();

//        //    }

//        //    _logger.LogInformation("Login success: UserName={UserEmail},FirstName={FirstName},LastName={LastName}",
//        //    _user.UserEmail, _user.FirstName, _user.LastName);
//        //    return Ok(_user);

//        //}

//        //[HttpPost("Login")]
//        //public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData)
//        //{
//        //    // אנחנו יוצרים אובייקט User זמני רק כדי להעביר אותו ל-Service שמצפה ל-User
//        //    // או לחילופין מעדכנים את ה-Service (ראי סעיף הבא)
//        //    User userToLogin = new User
//        //    {
//        //        Email = loginData.Email,
//        //        Password = loginData.Password
//        //    };

//        //    UserDto _user = await _userService.login(userToLogin);

//        //    if (_user == null)
//        //    {
//        //        // שימי לב: בלוגין שנכשל אין לנו FirstName/LastName, לכן נתעד רק אימייל
//        //        _logger.LogInformation("Login failed for Email: {UserEmail}", loginData.Email);
//        //        return Unauthorized("אימייל או סיסמה שגויים"); // עדיף להחזיר 401 או 400 ולא NoContent
//        //    }

//        //    _logger.LogInformation("Login success: Email={UserEmail}, Name={FirstName} {LastName}",
//        //        _user.UserEmail, _user.FirstName, _user.LastName);

//        //    return Ok(_user);
//        //}

//        [HttpPost("Login")]
//        public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData) // <--- וודאי שכתוב UserLoginDto
//        {
//            // יצירת אובייקט זמני עבור ה-Service
//            User userToLogin = new User
//            {
//                Email = loginData.Email,
//                Password = loginData.Password
//            };

//            UserDto _user = await _userService.login(userToLogin);

//            if (_user == null) return Unauthorized("פרטים שגויים");

//            return Ok(_user);
//        }

//        //// PUT api/<UsersController>/5
//        //[HttpPut("{id}")]
//        //public IActionResult Put(int id, [FromBody] User user)
//        //{
//        //    _userService.updateUser(id,user);
//        //    return Ok(user);
//        //}

//        //[HttpPut("{id}")]
//        //public async Task<ActionResult<UserUpdateDto>> Put(int id, [FromBody] UserUpdateDto userDto)
//        //{
//        //    var result = await _userService.updateUser(id, userDto);
//        //    if (result == null) return NotFound();
//        //    return Ok(result);
//        //}

//        [HttpPut("{id}")]
//        public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserDto userDto)
//        {
//            var result = await _userService.updateUser(id, userDto);
//            if (result == null) return NotFound();
//            return Ok(result);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        }

//        // DELETE api/<UsersController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services;
using DTOs;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UserDTO? UserDTO { get; private set; }

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            UserDTO? user = await _userService.GetUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        // POST api/Users (רישום משתמש חדש)
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] User user)
        {
            // כאן נשמרת הלוגיקה שלך שבודקת אם המשתמש נוצר (כולל בדיקת סיסמה ב-Service)
            UserDTO? createdUser = await _userService.AddUser(user);

            if (createdUser == null)
            {
                _logger.LogWarning("Registration failed: Weak password or invalid data for {Email}", user.Email);
                return BadRequest("סיסמא חלשה - נסה סיסמא שונה");
            }

            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        // POST api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserLoginDTO loginData)
        {
            // יצירת אובייקט זמני עבור ה-Service שמצפה ל-User (הגישה של רחל)
            User userToLogin = new User
            {
                Email = loginData.Email,
                Password = loginData.Password
            };

            UserDTO? userDto = await _userService.Login(userToLogin);

            if (userDto == null)
            {
                _logger.LogInformation("Login failed for Email: {UserEmail}", loginData.Email);
                return Unauthorized("אימייל או סיסמה שגויים");
            }

            _logger.LogInformation("Login success: Email={UserEmail}", userDto.UserEmail);
            return Ok(userDto);
        }

        // PUT api/Users/5 (עדכון פרטים)
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UserDTO userDto)
        {
            var result = await _userService.UpdateUser(id, userDto);
            if (result == null)
                return NotFound("User not found or update failed");

            return Ok(result);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // אם תרצי לממש מחיקה בעתיד
            return Ok();
        }
    }
}