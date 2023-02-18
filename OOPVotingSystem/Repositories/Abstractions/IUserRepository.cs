using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByUsername(string username);

    Task<bool> ValidateUsername(string username);

    Task VerifyAccount(User entity);
}
