using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PolicyService.Bo.Infrastructure.Database;

namespace PricingService.Web.Infrastracture
{
    public static class EntityFrameworkAppBuilderExtensions
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PolicyDbContext>();
                context.Database.EnsureCreated();
            }

            return applicationBuilder;
        }
    }
}
