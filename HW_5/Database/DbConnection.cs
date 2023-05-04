using Microsoft.Extensions.Configuration;

namespace HW_5.Database
{
    internal class DbConnection
    {
        public static string ConnectionString { get; set; }

        static DbConnection()
        {
            var builder = new ConfigurationBuilder()
                        .AddJsonFile("dbsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

    }
}
