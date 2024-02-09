using Dapper;
using Microsoft.EntityFrameworkCore;
using PetShopCare.Foundation;
using PetShopCare.Library.Models;
using static PetShopCare.Foundation.SqlHelper;

namespace PetShopCare.Library.Managers
{
    public class UserManagerLight
    {
        public static async Task<Result<FoundOrNotFound<UserLight>>> GetById(Context context, Guid userId)
        {
            var query = Sql($"""
                SELECT UserID, UserEmail, UserPassword
                FROM tblUsers
                WHERE UserID = {userId}
                """);

            return await GetByQuery(context, query);
        }

        public static async Task<Result<FoundOrNotFound<UserLight>>> GetByEmail(Context context, string email)
        {
            var query = Sql($"""
                SELECT UserID, UserEmail, UserPassword
                FROM tblUsers
                WHERE UserEmail = {email}
                """);

            return await GetByQuery(context, query);
        }

        public static async Task<Result> Save(Context context, UserLight user)
        {
            var command = Sql($"""
                INSERT INTO tblUsers (UserID, UserEmail, UserPassword)
                VALUES ({user.UserID}, {user.UserEmail}, {user.UserPassword})
                """);
            try
            {
                await context.Connection.ExecuteAsync(command);
                return new Success();
            }
            catch (Exception ex)
            {
                return new Fail(new Error(ErrorCategory.DatabaseError, ex.Message));
            }
        }

        private static async Task<Result<FoundOrNotFound<UserLight>>> GetByQuery(Context context, string query)
        {
            try
            {
                var user = await context.Connection.QuerySingleOrDefaultAsync<UserLight>(query);
                if (user != null)
                    return new Success<FoundOrNotFound<UserLight>>(new Found<UserLight>(user));
                else
                    return new Success<FoundOrNotFound<UserLight>>(new NotFound<UserLight>());
            }
            catch (Exception ex)
            {
                return new Fail<FoundOrNotFound<UserLight>>(new Error(ErrorCategory.DatabaseError, ex.Message));
            }
        }
    }
}
