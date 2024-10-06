using LabFortyMS.Enums;

namespace LabFortyMS.Models.OrderForm
{
    public class OrderFormData
    {
        public int UserId { get; set; }
        public string Ticker { get; set; }
        public double Quantity { get; set; }
        public OrderSide Side { get; set; }
    }
}
