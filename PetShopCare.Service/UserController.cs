using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using PetShopCare.Foundation;
using PetShopCare.Library.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopCare.Service;

public class UserDTO
{
    public required Guid Id { get; set; }

    public required string Surname { get; set; }

    public required string FirstName { get; set; }

    public required string Email { get; set; }
}

public class UserController
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [Function("GetUser")]
    public async Task<HttpResponseData> GetUser(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users/{id}")]
            HttpRequestData req,
        Guid guid
    )
    {
        // TODO: Aggiungere autorizzazione
        // PATTERN MATCHING
        var context = ContextFactory.CreateContext();
        var res = await Library.Managers.UserManager.GetById(context, guid);
        return res switch
        {
            Success<FoundOrNotFound<User>>(var foundOrNotFound) => foundOrNotFound switch
            {
                Found<User>(var user) => Utilities.CreateResponseOk(req, ConvertFromUserToUserDTO(user)),
                NotFound<User> => Utilities.CreateResponseNotFound(req),
                _ => throw new ArgumentOutOfRangeException(),
            },
            Fail<FoundOrNotFound<User>>(var error) => Utilities.CreateResponseInternalServerError(req, error),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    /*
     *
     */
    [Function("SearchUser")]
    public async Task<HttpResponseData> SearchUser(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users")] HttpRequestData req,
        string searchString
    )
    {
        // TODO: Implemenentare la ricerca
        // TODO: Manca la firma del post, del put, del patch e del delete
        // PATTERN MATCHING
        // var res = await Library.Managers.UserManager.SearchBy(searchString);
        var res = new List<User>();

        return Utilities.CreateResponseOk(req, res.Select(ConvertFromUserToUserDTO));
    }

    /*
     *  scelta architetturale se inserire il DTO nella libreria o all'interno dell'API
     */
    private static UserDTO ConvertFromUserToUserDTO(User user) =>
        new()
        {
            Id = user.Id,
            Surname = user.Surname,
            FirstName = user.FirstName,
            Email = user.Email
        };

    /*
     *  CQRS
     *  I post UPDATE e put INSERT
     *  res Success || Fail o
     */
    //[Function("PostUser")]
    //public async Task<HttpResponseData> InsertUser() { }
}
