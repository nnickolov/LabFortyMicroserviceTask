using LabFortyMS.Orders.Data.Models;

namespace LabFortyMS.Orders.Services.Model
{
    public class OrderCreateRequestModel
    {
        public int TickerId { get; set; }

        public double Quantity { get; set; }

        public OrderSide Side { get; set; }
    }
}
