using Microsoft.AspNetCore.Mvc;

using LabFortyMS.Models.OrderForm;

namespace LabFortyMS.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [Route("/api/order/add/{userId}")]
        public IActionResult Index([FromBody] OrderFormData orderFormData)
        {

            return View();
        }
    }
}
