using LabFortyMS.Common.Messages.Price;
using LabFortyMS.Common.Services.Messages;
using System;
using System.Threading.Tasks;

namespace LabFortyMS.Prices.Services
{
    public class PriceService : IPriceService
    {
        private const double MinPrice = 1.0;
        private const double MaxPrice = 1000.0;

        private readonly IPublisher _publisher;

        public PriceService(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task<decimal> GenerateAsync()
        {
            var random = new Random();

            var randomPrice = (decimal)(MinPrice + (random.NextDouble() * (MaxPrice - MinPrice)));

            var message = new PriceUpdatedMessage
            {
                Price = randomPrice
            };

            await _publisher.Publish(message);

            return randomPrice;
        }
    }
}
