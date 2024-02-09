﻿using PetShopCare.Foundation;
using PetShopCare.Library.Models;

namespace PetShopCare.Library.Test;

public static class UserManagerTest
{
    public static async Task TestCountUsers()
    {
        var res = await Managers.UserManager.CountUsers();
        var output = res switch
        {
            Success<int>(var count) => $"Count: {count}",
            Fail<int>(var error) => $"Fail{error.Message}",
            _ => throw new ArgumentOutOfRangeException(),
        };
        await Console.Out.WriteLineAsync(output);
    }
    public static async Task TestGetUserById()
    {
        // PATTERN MATCHING
        var context = ContextFactory.CreateContext();
        var guid = Guid.NewGuid();
        var res = await Managers.UserManager.GetById(context, guid);
        var output = res switch
        {
            Success<FoundOrNotFound<User>>(var foundOrNotFound) => foundOrNotFound switch
            {
                Found<User>(var user) => $"User: {user.Email}",
                NotFound<User> => "User not found",
                _ => throw new ArgumentOutOfRangeException(),
            },
            Fail<FoundOrNotFound<User>>(var error) => $"Fail{error.Message}",
            _ => throw new ArgumentOutOfRangeException(),
        };
        await Console.Out.WriteLineAsync(output);
    }

    public static async Task TestUpdateUser()
    {
        // PATTERN MATCHING
        /*
         *  carico un utente, lo modifico e lo salvo
         *  dovrei fare una query nel db per verificare l'esistenza
         *  oppure fare un mock della DAL (Data access layer)
         */
        var context = ContextFactory.CreateContext();
        var guid = Guid.NewGuid();
        var res = await Managers.UserManager.GetById(context, guid);
        User userToBeUpdated;
        switch (res)
        {
            case Success<FoundOrNotFound<User>>(var foundOrNotFound):
                switch (foundOrNotFound)
                {
                    case Found<User>(var user):
                        userToBeUpdated = user;
                        
                        break;
                    case NotFound<User>:
                        await Console.Out.WriteLineAsync("User not found");
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case Fail<FoundOrNotFound<User>>(var error):
                await Console.Out.WriteLineAsync($"Fail{error.Message}");
                return;
            default:
                throw new ArgumentOutOfRangeException();
        }
        userToBeUpdated.FirstName = "Pippo";
        var resSave = await Managers.UserManager.Save(context, userToBeUpdated);
        var output = resSave switch
        {
            Success => "Success",
            Fail(var error) => $"Fail{error.Message}",
            _ => throw new ArgumentOutOfRangeException(),
        };
        await Console.Out.WriteLineAsync(output);
        //var userToBeUpdated = res switch
        //{
        //    Found<User>(var user) => user,
        //    NotFound<User> => throw new Exception("Test failed, user not found"),
        //    _ => throw new ArgumentOutOfRangeException(),
        //};

        //userToBeUpdated.FirstName = "Pippo";
        //// => user ? Success | Fail
        //var resSave = await Managers.UserManager.Save(userToBeUpdated);
        //var output = resSave switch
        //{
        //    Success => "Success",
        //    Fail(var error) => $"Fail{error.message}",
        //    _ => throw new ArgumentOutOfRangeException(),
        //};

        //await Console.Out.WriteLineAsync(output);
    }
}
