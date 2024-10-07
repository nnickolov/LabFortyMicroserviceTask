using LabFortyMS.Orders.Data.Models;

namespace LabFortyMS.Orders.Services.Models
{
    public class OrderCreateRequestModel
    {
        public string Ticker { get; set; }

        public double Quantity { get; set; }

        public OrderSide Side { get; set; }

        public decimal Price { get; set; }
    }
}
