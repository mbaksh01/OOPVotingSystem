using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Service;

public class PartyService : IPartyService
{
	private readonly ILogger<PartyService> _logger;

	private readonly IPartyRepository _partyRepository;

	private readonly IRepository<Address> _addressRepository;

    public PartyService(IRepository<Address> addressRepository, IPartyRepository partyRepository)
    {
        _addressRepository = addressRepository;
        _partyRepository = partyRepository;
    }

    public async Task<IEnumerable<Party>> GetAllPartiesAsync()
    {
        IEnumerable<Party> parties = await _partyRepository.GetAllAsync();

        IEnumerable<Address> addresses = await _addressRepository.GetAllAsync();

        foreach (Party party in parties)
        {
            party.OperationAddress = addresses.First(t => t.Id == party.AddressId);
        }

        return parties;
    }
}
