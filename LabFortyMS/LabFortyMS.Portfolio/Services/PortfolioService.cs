using LabFortyMS.Portfolio.Data;
using LabFortyMS.Portfolio.Data.Models;
using LabFortyMS.Portfolio.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LabFortyMS.Portfolio.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly PortfolioDbContext _context;

        public PortfolioService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PortfolioCreateRequestModel request)
        {
            var portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.UserId == request.UserId);

            portfolio ??= new Data.Models.Portfolio
            {
                UserId = request.UserId
            };

            portfolio.Orders.Add(new Order
            {
                Ticker = request.Ticker,
                Quantity = request.Quantity,
                Price = request.Price
            });

            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
        }
    }
}
