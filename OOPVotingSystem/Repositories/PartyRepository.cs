using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public class PartyRepository : IPartyRepository
{
    private readonly Database _database;

    public PartyRepository(Database database)
    {
        _database = database;
    }

    public async Task<Party> CreateAsync(Party entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _database.AddAsync(entity);

        _ = await _database.SaveChangesAsync();

        return entity;
    }
    
    public void CreateBudget(string id, string electionId) => throw new NotImplementedException();
    
    public Task CreateBudgetAsync(string id, string electionId) => throw new NotImplementedException();
    
    public void CreateCampaign(string id, string electionId) => throw new NotImplementedException();
    
    public Task CreateCampaignAsync(string id, string electionId) => throw new NotImplementedException();
    
    public void CreateCost(string id, string electionId) => throw new NotImplementedException();
    
    public Task CreateCostAsync(string id, string electionId) => throw new NotImplementedException();
    
    public async Task DeleteAsync(string id)
    {
        Party party = await _database.Parties.FindAsync(id) ?? throw new ArgumentException(
            "The provide id was not associated with any parties.",
            nameof(id)
            );

        _database.Parties.Remove(party);

        _ = await _database.SaveChangesAsync();
    }

    public Task<IEnumerable<Party>> GetAllAsync()
        => Task.FromResult<IEnumerable<Party>>(_database.Parties);
    
    public async Task<Party> GetByIdAsync(string id)
    {
        return await _database.Parties.FindAsync(id) ?? throw new ArgumentException(
            "The provide id was not associated with any parties.",
            nameof(id)
            );
    }
    
    public double GetRemainingBudget(string id, string electionId) => throw new NotImplementedException();
    
    public Task<double> GetRemainingBudgetAsync(string id, string electionId) => throw new NotImplementedException();
    
    public async Task UpdateAsync(string id, Party entity)
    {
        _ = _database.Parties.Update(entity);

        _ = await _database.SaveChangesAsync();
    }
}
