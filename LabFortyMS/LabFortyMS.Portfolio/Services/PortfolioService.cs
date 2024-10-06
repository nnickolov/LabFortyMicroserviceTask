using LabFortyMS.Portfolio.Data;
using LabFortyMS.Portfolio.Data.Models;
using LabFortyMS.Portfolio.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task UpdatePricesAsync(decimal price)
        {
            var orders = await _context.Orders.ToListAsync();

            foreach (var order in orders)
            {
                order.Price = price;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<UserPortfolioResponseModel> GetForUserAsync(int userId)
        {
            return await _context
                .Portfolios
                .Where(p => p.UserId == userId)
                .Select(p => new UserPortfolioResponseModel
                {
                    UserId = p.UserId,
                    Orders = p.Orders
                        .Select(o => new PortfolioOrderResponseModel
                        {
                            Ticker = o.Ticker,
                            Total = (decimal)o.Quantity * o.Price,
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
