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

    public static async Task<FoundOrNotFound<User>> GetById(Context context, Guid userId)
    {
        var user = await context.Database.Users.FirstOrDefaultAsync(s => s.Id == userId);

        if (user == null)
            return new NotFound<User>();

        return new Found<User>(user);
    }
    
    /// <summary>
    ///  questo è un esempio volutamente stupido
    /// </summary>
    /// <param name="context"></param>
    /// <param name="lenght"></param>
    /// <returns></returns>
    public static async Task<FoundOrNotFound<User>> GetByLegthOfEmail(Context context, int lenght)
    {
        var user = await context.Database.Users.FirstOrDefaultAsync(s => s.Email.Length == lenght);

        if (user == null)
            return new NotFound<User>();

        return new Found<User>(user);
    }

    // Sia per le insert che per le update
    public static async Task<SuccessOrFail> Save(Context context, User user)
    {
        // effettuo il salvataggio dell'user
        try
        {
            await context.Database.SaveChangesAsync();

            return new Success();
        }
        catch (Exception exception)
        {
            return new Fail(Utilities.CaptureException(exception));
        }
    }

    public static User Delete(Guid userId)
    {
        // TODO implement this method
        throw new NotImplementedException();
    }
}
