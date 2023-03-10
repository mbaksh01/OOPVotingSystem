using System.ComponentModel.DataAnnotations;

namespace OOPVotingSystem.Models;

public class User
{
    [Key]
    public string Username { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string PersonId { get; set; } = default!;

    public virtual Person Person { get; set; } = default!;

    public bool IsAdmin() => Username.ToLower().Contains("admin");
}
