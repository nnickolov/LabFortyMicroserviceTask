using LabFortyMS.Common.Messages.Price;
using LabFortyMS.Portfolio.Services;
using MassTransit;
using System.Threading.Tasks;

namespace LabFortyMS.Portfolio.Messages
{
    public class PriceUpdatedConsumer : IConsumer<PriceUpdatedMessage>
    {
        private readonly IPortfolioService _portfolioService;

        public PriceUpdatedConsumer(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task Consume(ConsumeContext<PriceUpdatedMessage> context)
        {
            var message = context.Message;

            await _portfolioService.UpdatePricesAsync(message.Price);
        }
    }
}
