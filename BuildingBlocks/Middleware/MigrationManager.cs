using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware
{
    public static class MigrationManager
    {
        public static void UpdateDatabase<TContext>(IApplicationBuilder app)
            where TContext : DbContext
        {
            Task.Run(() =>
            {
                using var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();

                using var context = serviceScope.ServiceProvider
                    .GetRequiredService<TContext>();

                context.Database.SetCommandTimeout(1000);
                context.Database.Migrate();
            });
        }
    }
}
