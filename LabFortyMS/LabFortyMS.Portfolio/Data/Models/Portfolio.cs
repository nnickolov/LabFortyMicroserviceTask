using LabFortyMS.Common.Data.Models;
using System.Collections.Generic;

namespace LabFortyMS.Portfolio.Data.Models
{
    public class Portfolio : BaseModel
    {
        public int UserId { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
