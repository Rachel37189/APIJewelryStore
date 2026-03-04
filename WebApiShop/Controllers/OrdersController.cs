//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using static WebApiShop.Controllers.UsersController;
//using Entities;
//using Repository;
//using Services;
//using DTOs;
//<<<<<<< HEAD
//=======
//using AutoMapper;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApiShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {

//<<<<<<< HEAD
//        public readonly IOrderService _orderService;
//        public OrdersController(IOrderService orderService)
//        {
//            _orderService = orderService;
//        }

//        //// GET: api/<UsersController>
//        //[HttpGet]
//        //public IEnumerable<string> Get()
//        //{
//        //    return new string[] { "value1", "value2" };
//        //}

//        // GET api/<UsersController>/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrderDTO>> Get(int id)
//        {

//            OrderDTO order= await _orderService.GetOrderById(id);
//=======
//        IOrderService _orderService;
//        IMapper _mapper;
//        public OrdersController(IOrderService orderService,IMapper mapper)
//        {
//            _orderService = orderService;
//            _mapper = mapper;
//        }

//        // GET: api/<UsersController>
//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
//        //{
//        //    var orders = await _orderService.GetAllOrders(); // צריכה להוסיף את המתודה הזו ב-Service
//        //    return Ok(orders);
//        //}

//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
//        //{
//        //    // 1. שליפת הנתונים הגולמיים מה-DB (כאן TotalPrice מלא)
//        //    var orders = await _orderService.GetAllOrders();

//        //    // 2. הפעלת הקסם של AutoMapper - העברה מ-Order ל-OrderDto
//        //    var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

//        //    // 3. החזרת ה-DTO הממופה (כאן OrderSum יהיה שווה ל-TotalPrice)
//        //    return Ok(ordersDto);
//        //}

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
//        {
//            var ordersDto = await _orderService.GetAllOrders();
//            return Ok(ordersDto);
//        }

//        // GET api/<UsersController>/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrderDto>> Get(int id)
//        {

//            OrderDto order= await _orderService.GetOrderById(id);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//            if (order == null)
//                   return NoContent();
//            return Ok(order);
//        }
//<<<<<<< HEAD
//        // POST api/<UsersController>
//        [HttpPost]
//        //public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO order)
//        //{
//        //    OrderDTO _order = await _orderService.addOrder(order);
//        //    if (_order == null)
//        //    {
//        //        return BadRequest();
//        //    }
//        //  return CreatedAtAction(nameof(Get), new {id= _order.OrderId }, _order);
//        //   //return Ok(_order);

//        //}
//        [HttpPost]
//        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderCreateDTO dto)
//        {
//            try
//            {
//                var created = await _orderService.CreateOrderAsync(dto);
//                return CreatedAtAction(nameof(Get), new { id = created.OrderId }, created);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }


//=======

//        // GET: api/Orders/user/5
//        [HttpGet("user/{userId}")]
//        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserId(int userId)
//        {
//            // 1. קריאה לשירות שיביא את ההזמנות של המשתמש הספציפי
//            var orders = await _orderService.GetOrdersByUserId(userId);

//            // 2. בדיקה אם קיימות הזמנות
//            if (orders == null || !orders.Any())
//            {
//                return Ok(new List<OrderDto>()); // מחזירים רשימה ריקה אם אין הזמנות
//            }

//            // 3. החזרת הנתונים (הם כבר ממופים ל-DTO בתוך ה-Service)
//            return Ok(orders);
//        }


//        // POST api/<UsersController>
//        [HttpPost]
//        public async Task<ActionResult<OrderDto>> Post([FromBody] Order order)
//        { 
//            OrderDto _order = await _orderService.addOrder(order);
//            if (_order == null)
//            {
//                return BadRequest("order added");
//            }
//            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);

//        }

//        // PUT: api/Orders/5/status
//        [HttpPut("{id}/status")]
//        public async Task<IActionResult> UpdateStatus(int id, [FromBody] int newStatus)
//        {
//            var success = await _orderService.UpdateStatus(id, newStatus);

//            if (!success)
//            {
//                return NotFound($"Order with ID {id} not found.");
//            }

//            return Ok(new { message = "Status updated successfully", status = newStatus });
//        }

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Services;
using System;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // 1. שליפת כל ההזמנות (של רחל)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Get()
        {
            var ordersDto = await _orderService.GetAllOrders();
            return Ok(ordersDto);
        }

        // 2. שליפת הזמנה ספציפית (משותף)
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO? order = await _orderService.GetOrderById(id);
            if (order == null)
                return NoContent();
            return Ok(order);
        }

        // 3. שליפת הזמנות של משתמש ספציפי (של רחל)
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByUserId(int userId)
        {
            var orders = await _orderService.GetOrdersByUserId(userId);
            if (orders == null || !orders.Any())
            {
                return Ok(new List<OrderDTO>());
            }
            return Ok(orders);
        }

        // 4. יצירת הזמנה חדשה - עם הלוגיקה המורכבת שלך! (הגרסה שלך)
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderCreateDTO dto)
        {
            try
            {
                var created = await _orderService.CreateOrderAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = created.OrderId }, created);
            }
            catch (Exception ex)
            {
                // כאן יחזרו השגיאות מה-Service (עגלה ריקה, משתמש לא קיים וכו')
                return BadRequest(ex.Message);
            }
        }

        // 5. עדכון סטטוס הזמנה (של רחל)
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