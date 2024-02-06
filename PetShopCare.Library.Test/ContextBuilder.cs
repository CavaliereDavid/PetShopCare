using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PetShopCare.Library.Test
{
    internal static class ContextBuilder
    {
        internal static Context GetContext()
        {
            // read configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration?["ConnectionStrings:CurrentDb"] ?? "";

            return new Context { 
                Connection = new SqlConnection(connectionString),
                Database = new PetShopCareDbContext(GetDbContextOptions(connectionString)),
            };

        }

        private static DbContextOptions GetDbContextOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(connectionString);
            //opt.UseLoggerFactory(AwmDbContext._loggerFactory);
            //opt.EnableSensitiveDataLogging();

            return optionsBuilder.Options;
        }

    }
}
