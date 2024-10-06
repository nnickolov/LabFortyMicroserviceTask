using LabFortyMS.Common.Controllers;
using LabFortyMS.Orders.Services;
using LabFortyMS.Orders.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LabFortyMS.Orders.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        [Route("add/{userId}")]
        public async Task<ActionResult<int>> Create(int userId, [FromBody] OrderCreateRequestModel request)
        {
            return await _ordersService.CreateOrderAsync(userId, request);
        }
    }
}
