using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static WebApiShop.Controllers.UsersController;
using Entities;
using Repository;
using Services;
using DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        IUserService _userService ;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;

        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
           
            UserDto user= await _userService.GetUserById(id);
            if (user == null)
                   return NoContent();
            return Ok(user);
        }
        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] User user)
        {
            UserDto _user =await _userService.addUser(user);
            if (_user == null)
            {
                return BadRequest("סיסמא חלשה - נסה סיסמא שונה");
            }
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);

        }

        //[HttpPost("Login")]
        //public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData)
        //{
        //    UserDto _user = await _userService.login(user);
        //    if (_user == null)
        //    {
        //        _logger.LogInformation("Login failed: UserName={UserEmail},FirstName={FirstName},LastName={LastName}", user?.Email, user?.FirstName, user?.LastName);
        //        return NoContent();

        //    }

        //    _logger.LogInformation("Login success: UserName={UserEmail},FirstName={FirstName},LastName={LastName}",
        //    _user.UserEmail, _user.FirstName, _user.LastName);
        //    return Ok(_user);

        //}

        //[HttpPost("Login")]
        //public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData)
        //{
        //    // אנחנו יוצרים אובייקט User זמני רק כדי להעביר אותו ל-Service שמצפה ל-User
        //    // או לחילופין מעדכנים את ה-Service (ראי סעיף הבא)
        //    User userToLogin = new User
        //    {
        //        Email = loginData.Email,
        //        Password = loginData.Password
        //    };

        //    UserDto _user = await _userService.login(userToLogin);

        //    if (_user == null)
        //    {
        //        // שימי לב: בלוגין שנכשל אין לנו FirstName/LastName, לכן נתעד רק אימייל
        //        _logger.LogInformation("Login failed for Email: {UserEmail}", loginData.Email);
        //        return Unauthorized("אימייל או סיסמה שגויים"); // עדיף להחזיר 401 או 400 ולא NoContent
        //    }

        //    _logger.LogInformation("Login success: Email={UserEmail}, Name={FirstName} {LastName}",
        //        _user.UserEmail, _user.FirstName, _user.LastName);

        //    return Ok(_user);
        //}

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData) // <--- וודאי שכתוב UserLoginDto
        {
            // יצירת אובייקט זמני עבור ה-Service
            User userToLogin = new User
            {
                Email = loginData.Email,
                Password = loginData.Password
            };

            UserDto _user = await _userService.login(userToLogin);

            if (_user == null) return Unauthorized("פרטים שגויים");

            return Ok(_user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            _userService.updateUser(id,user);
            return Ok(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
