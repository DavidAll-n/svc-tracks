using Domain.Entities.v1;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class TxContext : DbContext
    {
        private readonly string? _connectionString = null;

        public TxContext() { }

        public TxContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TxContext(DbContextOptions<TxContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), true);
                var config = builder.Build();

                var connectionString = config.GetConnectionString("TxConnectionString");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    var prefix = "TX_DB";
                    connectionString = prefix.BuildPostgresConnectionString();
                }
                optionsBuilder.UseNpgsql(connectionString, o => o.UseNetTopologySuite());
            }
        }

        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Fleet> Fleets { get; set; }

        // Partitioning
        public DbSet<DataPointTemplate> DataPointTemplate { get; set; }
    }
}
