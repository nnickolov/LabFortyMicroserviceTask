using LabFortyMS.Common.Data.Models;
using System.Collections.Generic;

namespace LabFortyMS.Orders.Data.Models
{
    public class Price : BaseModel
    {
        public decimal? Buy { get; set; }

        public decimal? Sell { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

        public ICollection<Ticker> Tickers { get; } = new List<Ticker>();
    }
}