using Microsoft.AspNetCore.Builder;
using PolicyService.Web.Infrastructure.Middlewares;

namespace PolicyService.Web.Infrastructure
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
