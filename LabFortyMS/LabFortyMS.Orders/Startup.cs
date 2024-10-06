using LabFortyMS.Common.Extensions;
using LabFortyMS.Common.Services.Messages;
using LabFortyMS.Orders.Data;
using LabFortyMS.Orders.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabFortyMS.Orders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<OrdersDbContext>(this.Configuration)
                .AddMessaging(this.Configuration)
                .AddTransient<IOrdersService, OrdersService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize<OrdersDbContext>();
    }
}
