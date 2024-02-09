using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PetShopCare.Library.Test
{
    public class ContextFactory
    {
        public static Context CreateContext()
        {
            //var options = new DbContextOptionsBuilder<PetShopCareDbContext>()
            //    .UseInMemoryDatabase(databaseName: "PetShopCare")
            //    .Options;
            //var context = new PetShopCareDbContext(options);
            //return new Context { Database = context };

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration?["ConnectionStrings:CurrentDb"] ?? "";

            return new Context { 
                Connection = new SqlConnection(connectionString),
                Database = new PetShopCareDbContext(GetDbContextOptions(connectionString)),
                Settings = new Settings { NotificationRecipient = "mario.rossi@gmail.com" }
            };
        }

        private static DbContextOptions GetDbContextOptions(string connectionString)
        {
            var options = new DbContextOptionsBuilder()
                            .UseSqlServer(connectionString)
                            .Options;
            return options;
        }
    }


}
