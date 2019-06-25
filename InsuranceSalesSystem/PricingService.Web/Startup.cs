using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PricingService.Bo.Handlers;
using PricingService.Bo.Infrastructure.Database;
using PricingService.Web.Infrastracture;

namespace PricingService.Web
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
            services.AddMediatR(typeof(CalculatePriceHandler).Assembly);
            services.AddDbContext<PricingDbContext>(options =>
            //    options.UseInMemoryDatabase("PricingDb"));
             options.UseSqlServer(Configuration.GetConnectionString("PricingDb")));
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
