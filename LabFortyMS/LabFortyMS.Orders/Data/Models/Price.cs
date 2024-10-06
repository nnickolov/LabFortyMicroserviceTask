using LabFortyMS.Common.Data.Models;

namespace LabFortyMS.Orders.Data.Models
{
    public class Price : BaseModel
    {
        public double? Buy { get; set; }

        public double? Sell { get; set; }
    }
}