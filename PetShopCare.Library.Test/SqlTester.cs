using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PetShopCare.Foundation.SqlHelper;
using PetShopCare.Library;
using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using PetShopCare.Foundation;

namespace PetShopCare.Library.Test
{

    internal static class SqlTester
    {
        internal static async Task TestSql(Context context)
        {
            var email = "lorenzo.tagliaro@gmail.com";

            var res = await AlternativeUserManager.GetUserByEmail(context, email);

            switch (res)
            {
                case Found<UserLight>(var foundUser):
                    Console.WriteLine(foundUser.UserEmail);
                    break;
                case NotFound<UserLight>:
                    Console.WriteLine("User not found");
                    break;
            }
        }

        internal static async Task TestSql2(Context context)
        {
            var user = new UserLight
            {
                UserID = Guid.NewGuid(),
                UserEmail = "lorenzo.tagliaro@gmail.com"
            };
            SuccessOrFail res = await AlternativeUserManager.SaveUser(context, user);

            switch (res)
            {
                case Success:
                    Console.WriteLine("Success");
                    break;
                case Fail(var error):
                    Console.WriteLine("Fail - error:" + error.Message);
                    break;
            }
        }
    }
}
