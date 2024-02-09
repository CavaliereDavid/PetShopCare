using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShopCare.Library.Models;

namespace PetShopCare.Library
{
    public class PetShopCareDbContext(DbContextOptions options): DbContext(options)
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { /* builder.AddConsole();*/ });

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
