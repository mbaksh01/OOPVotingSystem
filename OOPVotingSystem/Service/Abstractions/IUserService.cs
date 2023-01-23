using OOPVotingSystem.Models;

namespace OOPVotingSystem.Service.Abstractions;

public interface IUserService
{
    public User? CurrentUser { get; set; }

    public Action<User?>? CurrentUserChanged { get; set; }

    Task CreateAccountAsync(User user);

    Task<bool> Login(string username, string password);
}
