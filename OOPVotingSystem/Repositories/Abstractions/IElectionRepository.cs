using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public interface IElectionRepository : IRepository<Election>
{
    Task<Election> GetElectionByNameAsync(string name);
}
