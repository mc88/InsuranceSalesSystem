using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PolicyService.Bo.Infrastructure.Database;

namespace PricingService.Web.Infrastracture
{
    public static class EntityFrameworkAppBuilderExtensions
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder applicationBuilder, bool insertSampleData)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PolicyDbContext>();

                try
                {
                    context.Database.EnsureCreated();

                    if (insertSampleData)
                    {
                        SampleDataSeed.InsertSampleData(context);
                    }
                }
                finally
                {
                    context.Dispose();
                }
            }

            return applicationBuilder;
        }
    }
}
