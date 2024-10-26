using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class DbMigrator
    {
        public static IHost MigrateTxDb(this IHost builder)
        {
            using (var scope = builder.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<TxContext>())
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        var migrator = context.Database.GetService<IMigrator>();
                        migrator.Migrate();
                    }
                }
            }

            return builder;
        }
    }
}
