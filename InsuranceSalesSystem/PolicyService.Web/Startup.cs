using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PolicyService.Bo.Handlers;
using PolicyService.Bo.Infrastructure.Communication.Events;
using PolicyService.Bo.Infrastructure.Communication.REST;
using PolicyService.Bo.Infrastructure.Database;
using PricingService.Web.Infrastracture;
using RabbitMQ.Client;

namespace PolicyService.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMediatR(typeof(OfferCreationHandler).Assembly);
            services.AddDbContext<PolicyDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("PolicyDb")));
            services.AddScoped(x => new PricingApiFacade(Configuration.GetSection("ApiUrls")["PricingApiUrl"]));
            services.AddScoped<IConnectionFactory>(x => 
                new ConnectionFactory()
                {
                    HostName = Configuration.GetSection("RabbitMq")["HostName"]
                });
            services.AddScoped<IEventPublisher, EventPublisher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.InitializeDatabase();
        }
    }
}
