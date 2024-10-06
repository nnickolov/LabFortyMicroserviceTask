using LabFortyMS.Common.Data.Models;

namespace LabFortyMS.Portfolio.Data.Models
{
    public class Order : BaseModel
    {
        public string Ticker { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public int PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
