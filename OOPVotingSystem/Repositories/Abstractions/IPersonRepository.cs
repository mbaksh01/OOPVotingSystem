using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public interface IPersonRepository : IRepository<Person>
{
    void RegisterToVote(string id);

    Task RegisterToVoteAsync(string id);

    void CastVote(Vote vote);

    Task CastVoteAsync(Vote vote);

    bool IsVerified(string id);

    Task<bool> IsVerifiedAsync(string id);

    bool HasAcceptedTerms(string id);

    Task<bool> HasAcceptedTermsAsync(string id);
}
