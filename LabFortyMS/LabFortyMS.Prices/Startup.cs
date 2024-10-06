using LabFortyMS.Common.Extensions;
using LabFortyMS.Prices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabFortyMS.Prices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddMessaging(this.Configuration)
                .AddTransient<IPriceService, PriceService>()
                .AddHangfireService<PriceUpdateHostedService>()
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env);
    }
}
