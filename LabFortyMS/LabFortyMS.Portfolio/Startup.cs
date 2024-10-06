using LabFortyMS.Common.Extensions;
using LabFortyMS.Portfolio.Data;
using LabFortyMS.Portfolio.Messages;
using LabFortyMS.Portfolio.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabFortyMS.Portfolio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<PortfolioDbContext>(this.Configuration)
                .AddTransient<IPortfolioService, PortfolioService>()
                .AddMessaging(this.Configuration, typeof(OrderCreatedConsumer));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize<PortfolioDbContext>();
    }
}
