using LabFortyMS.Common.Controllers;
using LabFortyMS.Portfolio.Services;
using LabFortyMS.Portfolio.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LabFortyMS.Portfolio.Controllers
{
    public class PortfoliosController : ApiController
    {
        private readonly IPortfolioService _portfoliosService;

        public PortfoliosController(IPortfolioService portfoliosService)
        {
            _portfoliosService = portfoliosService;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserPortfolioResponseModel>> Get(int userId)
        {
            return await _portfoliosService.GetForUserAsync(userId);
        }
    }
}
