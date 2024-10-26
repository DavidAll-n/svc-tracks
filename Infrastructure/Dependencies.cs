using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("TxConnectionString");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                var prefix = "TX_DB";
                connectionString = prefix.BuildPostgresConnectionString();
            }
            services.AddDbContext<TxContext>(options => options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));

            return services;
        }
    }
}
