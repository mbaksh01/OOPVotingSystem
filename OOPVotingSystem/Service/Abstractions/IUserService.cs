using OOPVotingSystem.Models;

namespace OOPVotingSystem.Service.Abstractions;

public interface IUserService
{
    public User? CurrentUser { get; set; }

    public Action<User?>? CurrentUserChanged { get; set; }

    Task<User> CreateAsync(User user);

    Task<bool> ValidateUsername(string username);

    Task<bool> Login(string username, string password);

    void Logout();

    Task VerifyUser();
}
