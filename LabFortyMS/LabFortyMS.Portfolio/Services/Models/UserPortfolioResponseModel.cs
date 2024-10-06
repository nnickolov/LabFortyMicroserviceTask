using System.Collections.Generic;

namespace LabFortyMS.Portfolio.Services.Models
{
    public class UserPortfolioResponseModel
    {
        public int UserId { get; set; }

        public IEnumerable<PortfolioOrderResponseModel> Orders { get; set; }
    }
}
