using Microsoft.Data.SqlClient;

namespace PetShopCare.Library
{
    public class Context
    {
        public required PetShopCareDbContext Database { get; init; }
        public required SqlConnection Connection { get; init; }

        public required Settings Settings { get; init; }
    }

    public class Settings
    {
        public required string NotificationRecipient { get; init; }
    }
}
