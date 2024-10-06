using LabFortyMS.Common.Data.Models;

namespace LabFortyMS.Orders.Data.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }

        public string Ticker { get; set; }

        public double Quantity { get; set; }

        public OrderSide Side { get; set; }

        public decimal Price { get; set; }
    }
}
