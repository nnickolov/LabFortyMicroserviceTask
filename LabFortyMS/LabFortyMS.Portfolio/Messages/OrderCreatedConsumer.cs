using LabFortyMS.Common.Messages.Orders;
using LabFortyMS.Portfolio.Services;
using LabFortyMS.Portfolio.Services.Models;
using MassTransit;
using System.Threading.Tasks;

namespace LabFortyMS.Portfolio.Messages
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedMessage>
    {
        private readonly IPortfolioService _portfolioService;

        public OrderCreatedConsumer(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task Consume(ConsumeContext<OrderCreatedMessage> context)
        {
            var message = context.Message;

            await _portfolioService.CreateAsync(new PortfolioCreateRequestModel
            {
                UserId = message.UserId,
                Ticker = message.Ticker,
                Quantity = message.Quantity,
                Price = message.Price,
            });
        }
    }
}
