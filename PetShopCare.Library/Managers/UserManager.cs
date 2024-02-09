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
    public static async Task<Result<FoundOrNotFound<User>>> GetById(Guid userId)
    {
        // TODO implement this method
        try
        {
            // TODO Scrivere la chiamata al database
            //var user = new User();
            //return new Success<FoundOrNotFound<User>>(new Found<User>(user));
            return new Success<FoundOrNotFound<User>>(new NotFound<User>());
        }
        catch (Exception ex)
        {
            return new Fail<FoundOrNotFound<User>>(new Error(ErrorCategory.DatabaseError, ex.Message));
        }
    }

    public static async Task<Result> Save(User user)
    {
        try
        {
            // TODO implement this method (chiamata al db)
            return new Success();
        }
        catch (Exception ex)
        {
            return new Fail(new Error(ErrorCategory.DatabaseError, ex.Message));
        }
    }

    // Sia per le insert che per le update
    //public static async Task<SuccessOrFail> Save(User user)
    //{
    //    // TODO implement this method
    //    throw new NotImplementedException();
    //}

    public static User Delete(Guid userId)
    {
        // TODO implement this method
        throw new NotImplementedException();
    }
}
