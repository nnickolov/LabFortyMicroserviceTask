using LabFortyMS.Common.Data.Models;

namespace LabFortyMS.Orders.Data.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }

        public int TickerId { get; set; }

        public Ticker Ticker { get; set; }

        public double Quantity { get; set; }

        public OrderSide Side { get; set; }

        public int PriceId { get; set; }

        public Price Price { get; set; }
    }
}
