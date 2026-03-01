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
    public class OrdersController : ControllerBase
    {

        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var orders = await _orderService.GetAllOrders(); // צריכה להוסיף את המתודה הזו ב-Service
            return Ok(orders);
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
