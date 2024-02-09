using Microsoft.EntityFrameworkCore;
using PetShopCare.Foundation;
using PetShopCare.Library.Models;

namespace PetShopCare.Library.Managers;

public static class UserManager
{
    public static User Add(User user)
    {
        // TODO implement this method
        throw new NotImplementedException();
    }
    public static async Task<Result<int>> CountUsers()
    {
        try
        {
            // TODO implement this method (chiamata al db)
            return new Success<int>(42);
        }
        catch (Exception ex)
        {
            return new Fail<int>(new Error(ErrorCategory.DatabaseError, ex.Message));
        }
    }
    public static async Task<Result<FoundOrNotFound<User>>> GetById(Context context ,Guid userId)
    {
        try
        {
            var user = await context.Database.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user != null)
                return new Success<FoundOrNotFound<User>>(new Found<User>(user));
            else 
                return new Success<FoundOrNotFound<User>>(new NotFound<User>());
        }
        catch (Exception ex)
        {
            return new Fail<FoundOrNotFound<User>>(new Error(ErrorCategory.DatabaseError, ex.Message));
        }
    }

    public static async Task<Result> Save(Context context, User user)
    {
        try
        {
            await context.Database.SaveChangesAsync();
            return new Success();
        }
        catch (Exception ex)
        {
            return new Fail(new Error(ErrorCategory.DatabaseError, ex.Message));
        }
    }

    public static User Delete(Context context, Guid userId)
    {
        // TODO implement this method
        throw new NotImplementedException();
    }
}
