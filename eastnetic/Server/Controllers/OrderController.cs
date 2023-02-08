using eastnetic.Server.Interfaces;
using eastnetic.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace eastnetic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _IOrder;

        public OrderController(IOrder iOrder)
        {
            _IOrder = iOrder;
        }

        [HttpGet]
        public async Task<List<Order>> Get()
        {
            return await Task.FromResult(_IOrder.GetOrderDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Order Order = _IOrder.GetOrderData(id);
            if (Order != null)
            {
                return Ok(Order);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Order Order)
        {
            _IOrder.AddOrder(Order);
        }

        [HttpPut]
        public void Put(Order Order)
        {
            _IOrder.UpdateOrderDetails(Order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IOrder.DeleteOrder(id);
            return Ok();
        }
    }
}