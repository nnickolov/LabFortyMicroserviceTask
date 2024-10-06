using LabFortyMS.Common.Data.Models;

namespace LabFortyMS.Orders.Data.Models
{
    public class Ticker : BaseModel
    {
        public string StockName { get; set; }

        public int PriceId { get; set; }

        public Price Price { get; set; }
    }
}
