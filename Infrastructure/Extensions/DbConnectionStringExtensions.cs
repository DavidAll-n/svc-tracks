using Infrastructure.DTO;

namespace Infrastructure.Extensions
{
    public static class DbConnectionStringExtensions
    {
        public static string? BuildPostgresConnectionString(this string dbPrefix)
        {
            if (string.IsNullOrWhiteSpace(dbPrefix))
            {
                return null;
            }

            var db = GetDbEnvVariables(dbPrefix);
            return $"host={db.Host};port={db.Port};database={db.DatabaseName};username={db.Username};password={db.Password};Include Error Detail=true";
        }

        public static DbConnectionDetail GetDbEnvVariables(this string dbPrefix)
        {
            return new DbConnectionDetail()
            {
                Host = Environment.GetEnvironmentVariable($"{dbPrefix}_HOST"),
                DatabaseName = Environment.GetEnvironmentVariable($"{dbPrefix}_NAME"),
                Username = Environment.GetEnvironmentVariable($"{dbPrefix}_USER"),
                Password = Environment.GetEnvironmentVariable($"{dbPrefix}_PASSWORD"),
                Port = Environment.GetEnvironmentVariable($"{dbPrefix}_PORT"),
            };
        }
    }
}
