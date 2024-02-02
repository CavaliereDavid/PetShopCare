using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopCare.Library.Models;

[Table("tblSessions", Schema = "dpo")]
public class Session
{
    [Column("SessionId")]
    public required Guid Id { get; set; }

    [Column("SessionRefUser")]
    public required Guid RefUser { get; set; }

    [Column("SessionToken")]
    public required Guid Token { get; set; }

    [Column("SessionStartTImeStamp")]
    public required DateTime StartTImeStamp { get; set; }

    [Column("SessionLastAccessTimeSTamp")]
    public required DateTime LastAccessTimeSTamp { get; set; }

    [Column("SessionEndTimeStamp")]
    public required DateTime EndTimeStamp { get; set; }
}
