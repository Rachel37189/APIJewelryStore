//using Entities;
//using Microsoft.AspNetCore.Mvc;
//using Services;
//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApiShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PasswordController : ControllerBase
//    {
//<<<<<<< HEAD
//        private readonly IPasswordService _pass;
//=======
//        IPasswordService _pass;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        public PasswordController(IPasswordService pass)
//        {
//            _pass = pass;
//        }

//<<<<<<< HEAD

//        // POST api/<PasswordController>
//        [HttpPost]
//        public async Task<ActionResult<int>> Post([FromBody] string pass)
//        {

//            PasswordEntity _passWord = await _pass.CheckPasswordStrength(pass);
//=======
//        // GET: api/<PasswordController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }
//        [HttpGet("check/{pass}")]
//        public ActionResult<int> GetPasswordStrength(string pass)
//        {
//            var result = _pass.Level(pass);
//            return Ok(result.Strength);
//        }
//        // GET api/<PasswordController>/5
//        [HttpGet("{pass}")]
//        public void Get(string pass)
//        {

//        }

//        // POST api/<PasswordController>
//        [HttpPost]
//        public ActionResult<string> Post([FromBody] string pass)
//        {

//            PasswordEntity _passWord = _pass.Level(pass);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//            if (_passWord == null)
//                return NoContent();

//            return Ok(_passWord.Strength);
//        }

//<<<<<<< HEAD

//=======
//        // PUT api/<PasswordController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<PasswordController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passService;

        public PasswordController(IPasswordService passService)
        {
            _passService = passService;
        }

        /// <summary>
        /// בדיקת חוזק סיסמה - מחזיר מספר בין 0 ל-4
        /// </summary>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            // השתמשנו בשם הפונקציה המעודכן מה-Service שסידרנו קודם
            int strength = _passService.CheckPasswordStrength(password);

            // בבדיקת חוזק סיסמה בדרך כלל לא חוזר null, אבל ליתר ביטחון:
            if (strength < 0)
                return BadRequest("Invalid password format");

            return Ok(strength);
        }

        // אפשרות נוספת לבדיקה דרך ה-URL (הגישה של רחל)
        [HttpGet("check/{password}")]
        public ActionResult<int> GetPasswordStrength(string password)
        {
            int strength = _passService.CheckPasswordStrength(password);
            return Ok(strength);
        }
    }
}