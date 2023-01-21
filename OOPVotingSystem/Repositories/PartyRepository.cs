using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public class PartyRepository : IPartyRepository
{
    private readonly PartyContext _partyContext;

    public PartyRepository(PartyContext partyContext)
    {
        _partyContext = partyContext;
    }

    public async Task<Party> CreateAsync(Party entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _partyContext.AddAsync(entity);

        _ = await _partyContext.SaveChangesAsync();

        return entity;
    }
    
    public void CreateBudget(string id, string electionId) => throw new NotImplementedException();
    
    public Task CreateBudgetAsync(string id, string electionId) => throw new NotImplementedException();
    
    public void CreateCampaign(string id, string electionId) => throw new NotImplementedException();
    
    public Task CreateCampaignAsync(string id, string electionId) => throw new NotImplementedException();
    
    public void CreateCost(string id, string electionId) => throw new NotImplementedException();
    
    public Task CreateCostAsync(string id, string electionId) => throw new NotImplementedException();
    
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    
    public Task<IEnumerable<Party>> GetAllAsync() => throw new NotImplementedException();
    
    public Task<Party> GetByIdAsync(string id) => throw new NotImplementedException();
    
    public double GetRemainingBudget(string id, string electionId) => throw new NotImplementedException();
    
    public Task<double> GetRemainingBudgetAsync(string id, string electionId) => throw new NotImplementedException();
    
    public Task UpdateAsync(string id, Party entity) => throw new NotImplementedException();
}
