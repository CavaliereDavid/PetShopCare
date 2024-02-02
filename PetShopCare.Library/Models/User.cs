using System.ComponentModel.DataAnnotations.Schema; // per gli attributi - Binding ef core

namespace PetShopCare.Library.Models;

[Table("tblUsers", Schema = "dbo")] // il dbo è lo schema name - concetto di organizzazione del db
public class User
{
    [Column("UserId")]
    public required Guid Id { get; set; }

    [Column("UserSurname")]
    public required string Surname { get; set; }

    [Column("UserFirstName")]
    public required string FirstName { get; set; }

    [Column("UserEmail")]
    public required string Email { get; set; }

    [Column("UserPassword")]
    public required string Password { get; set; }

    [Column("UserCreationTimeStamp")]
    public required DateTime CreationTimeStamp { get; set; }
}
