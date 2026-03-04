using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "היי! ה-API והאנגולר מחוברים בהצלחה!" });
        }
    }
}
