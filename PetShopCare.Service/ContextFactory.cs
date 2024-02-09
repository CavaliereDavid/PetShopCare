using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetShopCare.Library;

namespace PetShopCare.Service
{
    public class ContextFactory
    {
        public static Context CreateContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration?["ConnectionStrings:CurrentDb"] ?? "";
            var notificationRecipient = configuration?["NotificationRecipient"] ?? "mario.rossi@gmail.com";

            return new Context { 
                Connection = new SqlConnection(connectionString),
                Database = new PetShopCareDbContext(GetDbContextOptions(connectionString)),
                Settings = new Settings { NotificationRecipient = notificationRecipient }
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
