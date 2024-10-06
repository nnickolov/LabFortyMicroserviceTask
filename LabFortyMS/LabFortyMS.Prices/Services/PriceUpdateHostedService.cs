using Hangfire;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace LabFortyMS.Prices.Services
{
    public class PriceUpdateHostedService : IHostedService
    {
        private readonly IPriceService _priceService;
        private readonly IRecurringJobManager _recurringJob;

        public PriceUpdateHostedService(IPriceService priceService, IRecurringJobManager recurringJob)
        {
            _priceService = priceService;
            _recurringJob = recurringJob;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _recurringJob.AddOrUpdate(
                nameof(PriceUpdateHostedService),
                () => this.UpdatePrice(),
                "*/1 * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void UpdatePrice()
        {
            _priceService.GenerateAsync().GetAwaiter().GetResult();
        }
    }
}
