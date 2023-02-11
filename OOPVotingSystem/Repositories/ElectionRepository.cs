using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public class ElectionRepository : IElectionRepository
{
    private readonly ElectionContext _electionContext;

    public ElectionRepository(ElectionContext electionContext)
    {
        _electionContext = electionContext;
    }

    public async Task<Election> CreateAsync(Election entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _electionContext.Elections.AddAsync(entity);

        _ = await _electionContext.SaveChangesAsync();

        return entity;
    }
    
    public async Task DeleteAsync(string id)
    {
        Election election = await _electionContext.Elections.FindAsync(id) ?? throw new ArgumentException(
                "The id was not associated with any election.",
                nameof(id)
            );

        _ = _electionContext.Elections.Remove(election);

        _ = await _electionContext.SaveChangesAsync();
    }
    
    public Task<IEnumerable<Election>> GetAllAsync()
        => Task.FromResult<IEnumerable<Election>>(_electionContext.Elections);
    
    public async Task<Election> GetByIdAsync(string id)
    {
        Election? election = await _electionContext.Elections.FindAsync(id);

        return election is null
            ? throw new ArgumentException(
                "The id was not associated with any election.",
                nameof(id)
            )
            : election;
    }

    public async Task<Election> GetElectionByNameAsync(string name)
    {
        Election? election = await _electionContext.Elections.FirstOrDefaultAsync(t => t.Name == name);

        return election is null
            ? throw new ArgumentException(
                "The name was not associated with any election.",
                nameof(name)
            )
            : election;
    }

    public async Task UpdateAsync(string id, Election entity)
    {
        _ = _electionContext.Elections.Update(entity);

        _ = await _electionContext.SaveChangesAsync();
    }
}
