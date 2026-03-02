using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static WebApiShop.Controllers.UsersController;
using Entities;
using Repository;
using Services;
using DTOs;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        IOrderService _orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        //{
        //    var orders = await _orderService.GetAllOrders(); // צריכה להוסיף את המתודה הזו ב-Service
        //    return Ok(orders);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        //{
        //    // 1. שליפת הנתונים הגולמיים מה-DB (כאן TotalPrice מלא)
        //    var orders = await _orderService.GetAllOrders();

        //    // 2. הפעלת הקסם של AutoMapper - העברה מ-Order ל-OrderDto
        //    var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

        //    // 3. החזרת ה-DTO הממופה (כאן OrderSum יהיה שווה ל-TotalPrice)
        //    return Ok(ordersDto);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var ordersDto = await _orderService.GetAllOrders();
            return Ok(ordersDto);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
           
            OrderDto order= await _orderService.GetOrderById(id);
            if (order == null)
                   return NoContent();
            return Ok(order);
        }

        // GET: api/Orders/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserId(int userId)
        {
            // 1. קריאה לשירות שיביא את ההזמנות של המשתמש הספציפי
            var orders = await _orderService.GetOrdersByUserId(userId);

            // 2. בדיקה אם קיימות הזמנות
            if (orders == null || !orders.Any())
            {
                return Ok(new List<OrderDto>()); // מחזירים רשימה ריקה אם אין הזמנות
            }

            // 3. החזרת הנתונים (הם כבר ממופים ל-DTO בתוך ה-Service)
            return Ok(orders);
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] Order order)
        { 
            OrderDto _order = await _orderService.addOrder(order);
            if (_order == null)
            {
                return BadRequest("order added");
            }
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);

        }

        // PUT: api/Orders/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] int newStatus)
        {
            var success = await _orderService.UpdateStatus(id, newStatus);

            if (!success)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            return Ok(new { message = "Status updated successfully", status = newStatus });
        }

    }
}
