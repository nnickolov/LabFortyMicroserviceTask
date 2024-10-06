namespace LabFortyMS.Portfolio.Services.Models
{
    public class PortfolioCreateRequestModel
    {
        public int UserId { get; set; }

        public string Ticker { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
