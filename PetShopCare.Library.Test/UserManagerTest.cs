using PetShopCare.Foundation;
using PetShopCare.Library.Models;

namespace PetShopCare.Library.Test;

public static class UserManagerTest
{
    public static async Task TestGetUserById(Context context)
    {
        // PATTERN MATCHING
        var guid = Guid.NewGuid();
        var res = await Managers.UserManager.GetById(context, guid);
        var output = res switch
        {
            Found<User>(var user) => $"User: {user.Email}",
            NotFound<User> => "User not found",
            _ => throw new ArgumentOutOfRangeException(),
        };
        await Console.Out.WriteLineAsync(output);
    }

    public static async Task TestUpdateUser(Context context)
    {
        // PATTERN MATCHING
        /*
         *  carico un utente, lo modifico e lo salvo
         *  dovrei fare una query nel db per verificare l'esistenza
         *  oppure fare un mock della DAL (Data access layer)
         */
        var guid = Guid.NewGuid();
        var res = await Managers.UserManager.GetById(context, guid);
        var userToBeUpdated = res switch
        {
            Found<User>(var user) => user,
            NotFound<User> => throw new Exception("Test failed, user not found"),
            _ => throw new ArgumentOutOfRangeException(),
        };

        userToBeUpdated.FirstName = "Pippo";

        var guid2 = Guid.NewGuid();
        var res2 = await Managers.UserManager.GetById(context, guid2);
        var userToBeUpdated2 = res2 switch
        {
            Found<User>(var user) => user,
            NotFound<User> => throw new Exception("Test failed, user not found"),
            _ => throw new ArgumentOutOfRangeException(),
        };

        userToBeUpdated2.FirstName = "Paperino";



        // => user ? Success | Fail
        var resSave = await Managers.UserManager.Save(context, userToBeUpdated);
        var output = resSave switch
        {
            Success => "Success",
            Fail(var error) => $"Fail{error.Message}",
            _ => throw new ArgumentOutOfRangeException(),
        };

        await Console.Out.WriteLineAsync(output);
    }
}
