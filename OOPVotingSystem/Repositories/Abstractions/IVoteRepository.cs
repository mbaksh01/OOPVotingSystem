using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public interface IVoteRepository : IRepository<Vote>
{
    int CountVotes(string partyId);

    IDictionary<string, int> CountElectionVotes();

    Task<IDictionary<string, int>> CountElectionVotesAsync();

    IDictionary<string, int> CountPartyVotes(string electionId);
}
