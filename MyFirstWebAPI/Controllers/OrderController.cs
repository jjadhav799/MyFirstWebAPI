using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static List<Order> orders = new List<Order>
        {
            new Order { Id = 1, CustomerId = 101, Amount = 250.50M },
            new Order { Id = 2, CustomerId = 102, Amount = 400.00M }
        };

        // POST: api/order
        // Request Body Example: { "id": 3, "customerId": 103, "amount": 150.75 }
        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        // GET: api/order/2  --> Route parameter
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById([FromRoute] int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();


            return Ok(order);
        }

        // GET: api/order/query?id=2 --> Query string
        [HttpGet("query")]
        public ActionResult<Order> GetOrderByQuery([FromQuery] int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
