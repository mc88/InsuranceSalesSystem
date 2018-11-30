using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Bo.Handlers;
using PaymentService.Bo.Infrastructure.Database;
using PaymentService.Bo.Integration;
using PaymentService.Web.Listeners;
using PricingService.Web.Infrastracture;
using RabbitMQ.Client;

namespace PaymentService.Web
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
            services.AddMediatR(typeof(CreateAccountForPolicyHandler).Assembly);
            services.AddDbContext<PaymentDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("PaymentDb")));
            services.AddScoped<IConnectionFactory>(x =>
                new ConnectionFactory()
                {
                    HostName = Configuration.GetSection("RabbitMq")["HostName"]
                });
            services.AddScoped<IntegrationEventHandlerFactory>();
            services.AddSingleton<RabbitMqListener>();
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
            app.ApplicationServices.GetRequiredService<RabbitMqListener>().Listen();
        }
    }
}
