using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public interface IPersonRepository : IRepository<Person>
{
    void RegisterToVote();

    Task RegisterToVoteAsync();

    void CastVote();

    Task CastVoteAsync();

    bool IsVerified(string id);

    Task<bool> IsVerifiedAsync(string id);

    bool HasAcceptedTerms(string id);

    Task<bool> HasAcceptedTermsAsync(string id);
}
