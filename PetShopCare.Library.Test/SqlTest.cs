

using PetShopCare.Library.Models;
using PetShopCare.Foundation;
using static PetShopCare.Foundation.SqlHelper;

namespace PetShopCare.Library.Test
{
    internal class SqlTest
    {
        public static void SqlTest1()
        {
            var userId = Guid.NewGuid();
            //var userId = 42;
            var query = Sql($"""
                SELECT UserID, UserEmail, UserPassword
                FROM tblUsers
                WHERE UserID = {userId}
                """);

            Console.WriteLine(query);
        }
    }
}
