namespace LabFortyMS.Common.Messages.Orders
{
    public class OrderCreatedMessage
    {
        public int UserId { get; set; }

        public string Ticker { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
