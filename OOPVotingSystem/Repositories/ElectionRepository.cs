using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public class ElectionRepository : IElectionRepository
{
    private readonly Database _database;

    public ElectionRepository(Database database)
    {
        _database = database;
    }

    public async Task<Election> CreateAsync(Election entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _database.Elections.AddAsync(entity);

        _ = await _database.SaveChangesAsync();

        return entity;
    }
    
    public async Task DeleteAsync(string id)
    {
        Election election = await _database.Elections.FindAsync(id) ?? throw new ArgumentException(
                "The id was not associated with any election.",
                nameof(id)
            );

        _ = _database.Elections.Remove(election);

        _ = await _database.SaveChangesAsync();
    }
    
    public Task<IEnumerable<Election>> GetAllAsync()
        => Task.FromResult<IEnumerable<Election>>(_database.Elections);
    
    public async Task<Election> GetByIdAsync(string id)
    {
        Election? election = await _database.Elections.FindAsync(id);

        return election is null
            ? throw new ArgumentException(
                "The id was not associated with any election.",
                nameof(id)
            )
            : election;
    }

    public async Task<Election> GetElectionByNameAsync(string name)
    {
        Election? election = await _database.Elections.FirstOrDefaultAsync(t => t.Name == name);

        return election is null
            ? throw new ArgumentException(
                "The name was not associated with any election.",
                nameof(name)
            )
            : election;
    }

    public async Task UpdateAsync(string id, Election entity)
    {
        _ = _database.Elections.Update(entity);

        _ = await _database.SaveChangesAsync();
    }
}
