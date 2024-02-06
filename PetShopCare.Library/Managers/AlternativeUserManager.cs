using Dapper;
using PetShopCare.Library;
using static PetShopCare.Foundation.SqlHelper;
using PetShopCare.Foundation;


namespace PetShopCare.Library
{
    public class UserLight
    {
        public Guid UserID { get; set; }
        public string? UserEmail { get; set; }
    }
    public static class AlternativeUserManager
    {

        public static async Task<FoundOrNotFound<UserLight>> GetUserByEmail(Context context, string email)
        {
            var query = Sql($"""
                SELECT UserID, UserEmail
                FROM tblUsers
                WHERE UserEmail = {email}
                """);

            var user = await context.Connection.QueryFirstOrDefaultAsync<UserLight>(query);

            return user is not null ? new Found<UserLight>(user) : new NotFound<UserLight>();
        }

        public static async Task<SuccessOrFail> SaveUser(Context context, UserLight user)
        {
            var command = Sql($"""
                INSERT INTO tblUsers (UserID, UserEmail)
                VALUES ({user.UserID.ToString()}, {user.UserEmail});
                """);

            try
            {
                await context.Connection.ExecuteAsync(command);
                return new Success();
            }
            catch (Exception ex)
            {
                return new Fail(Utilities.CaptureException(ex));
            }
        }
    }
}