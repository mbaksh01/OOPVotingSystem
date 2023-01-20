using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public class VoteRepository : IVoteRepository
{
    private readonly VoteContext _voteContext;

    public VoteRepository(VoteContext voteContext)
    {
        _voteContext = voteContext;
    }

    public IDictionary<string, int> CountElectionVotes()
    {
        IDictionary<string, int> electionVotes = new Dictionary<string, int>();

        foreach (Vote vote in _voteContext.Votes)
        {
            if (electionVotes.ContainsKey(vote.ElectionId))
            {
                electionVotes[vote.ElectionId]++;
                continue;
            }

            electionVotes.Add(vote.ElectionId, 1);
        }

        return electionVotes;
    }

    public async Task<IDictionary<string, int>> CountElectionVotesAsync()
    {
        IDictionary<string, int> electionVotes = new Dictionary<string, int>();

        await foreach (Vote vote in _voteContext.Votes.AsAsyncEnumerable())
        {
            if (electionVotes.ContainsKey(vote.ElectionId))
            {
                electionVotes[vote.ElectionId]++;
                continue;
            }

            electionVotes.Add(vote.ElectionId, 1);
        }

        return electionVotes;
    }

    public IDictionary<string, int> CountPartyVotes(string electionId)
    {
        IDictionary<string, int> partyVotes = new Dictionary<string, int>();

        foreach (Vote vote in _voteContext.Votes.Where(t => t.ElectionId == electionId))
        {
            if (partyVotes.TryGetValue(vote.Candidate.PartyId, out int value))
            {
                value++;
            }
            
            partyVotes.Add(vote.Candidate.PartyId, 1);
        }

        return partyVotes;
    }

    public async Task<IDictionary<string, int>> CountPartyVotesAsync(string electionId)
    {
        IDictionary<string, int> partyVotes = new Dictionary<string, int>();

        IAsyncEnumerable<Vote> votes = _voteContext.Votes.Where(t => t.ElectionId == electionId).AsAsyncEnumerable();

        await foreach (Vote vote in votes)
        {
            if (partyVotes.TryGetValue(vote.Candidate.PartyId, out int value))
            {
                value++;
            }

            partyVotes.Add(vote.Candidate.PartyId, 1);
        }

        return partyVotes;
    }

    public int CountVotes(string partyId) => _voteContext.Votes.Count(t => t.Candidate.PartyId == partyId);

    public async Task<Vote> CreateAsync(Vote entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _voteContext.AddAsync(entity);

        _ = await _voteContext.SaveChangesAsync();

        return entity;
    }
    
    public async Task DeleteAsync(string id)
    {
        Vote vote = await GetVoteAsync(id);

        _ = _voteContext.Votes.Remove(vote);

        _ = await _voteContext.SaveChangesAsync();
    }
    
    public Task<IEnumerable<Vote>> GetAllAsync() => Task.FromResult(_voteContext.Votes.AsEnumerable());
    
    public Task<Vote> GetByIdAsync(string id) => GetVoteAsync(id);
    
    public async Task UpdateAsync(string id, Vote entity)
    {
        _ = _voteContext.Votes.Update(entity);

        _ = await _voteContext.SaveChangesAsync();
    }

    private Vote GetVote(string id)
    {
        Vote? vote = _voteContext.Votes.Find(id);

        if (vote is null)
        {
            throw new ArgumentException(
                "The primary key provided was not associated with any vote.", 
                nameof(id)
            );
        }

        return vote;
    }

    private async Task<Vote> GetVoteAsync(string id)
    {
        Vote? vote = await _voteContext.Votes.FindAsync(id);

        if (vote is null)
        {
            throw new ArgumentException(
                "The primary key provided was not associated with any vote.",
                nameof(id)
            );
        }

        return vote;
    }
}
