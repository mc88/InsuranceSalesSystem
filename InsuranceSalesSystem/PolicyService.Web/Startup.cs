using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PolicyService.Bo.Handlers;
using PolicyService.Bo.Infrastructure.Communication.Events;
using PolicyService.Bo.Infrastructure.Communication.REST;
using PolicyService.Bo.Infrastructure.Database;
using PolicyService.Web.Infrastructure;
using PricingService.Web.Infrastracture;
using RabbitMQ.Client;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;

namespace PolicyService.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;

            //TODO: check if configuring serilog must be in ctor and if can use Configuration prop instead building configuration here
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var elasticUri = Configuration["ElasticConfiguration:Uri"];

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    AutoRegisterTemplate = true,
                    MinimumLogEventLevel = LogEventLevel.Verbose,
                    FailureCallback = e => Console.WriteLine("ES ex: " + e.MessageTemplate)
                })
            .CreateLogger();
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //SelfLog will log problems with connection with ES to container logs
            //TODO check why Elasticsearch.Net.ElasticsearchClientException: Connection refused. is logged even if it is working - maybe container with api starts faster than with ES container
            Serilog.Debugging.SelfLog.Enable(message => Console.WriteLine(message));

            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();
            app.UseMvc();
            app.InitializeDatabase();
        }
    }
}
