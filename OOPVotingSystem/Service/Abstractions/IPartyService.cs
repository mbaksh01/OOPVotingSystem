using OOPVotingSystem.Models;

namespace OOPVotingSystem.Service.Abstractions;

public interface IPartyService
{
    Task<IEnumerable<Party>> GetAllPartiesAsync();
}
