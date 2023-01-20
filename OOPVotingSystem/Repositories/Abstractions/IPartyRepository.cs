using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public interface IPartyRepository : IRepository<Party>
{
    void CreateCampaign(string id, string electionId);
    
    Task CreateCampaignAsync(string id, string electionId);

    void CreateBudget(string id, string electionId);
    
    Task CreateBudgetAsync(string id, string electionId);

    void CreateCost(string id, string electionId);
    
    Task CreateCostAsync(string id, string electionId);

    double GetRemainingBudget(string id, string electionId);
    
    Task<double> GetRemainingBudgetAsync(string id, string electionId);
}
