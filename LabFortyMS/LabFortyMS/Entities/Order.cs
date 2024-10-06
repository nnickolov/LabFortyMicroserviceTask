using LabFortyMS.Enums;
using LabFortyMS.Entities.Abstraction;

namespace LabFortyMS.Entities
{
    public class Order : BaseModelClass
    {
        public int UserId { get; set; }
        public string Ticker { get; set; }
        public double Quantity { get; set; }
        public OrderSide Side { get; set; }
        public Price Prices { get; set; }
    }
}
