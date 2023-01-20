namespace OOPVotingSystem.Models;

public record Budget
{
    public Budget(string partyId, string electionId)
    {
        PartyId = partyId;
        ElectionId = electionId;
    }

    public Budget(string partyId, string electionId, double initialBudget)
    {
        PartyId = partyId;
        ElectionId = electionId;
        TotalBudget = initialBudget;
    }

    public string PartyId { get; init; }

    public string ElectionId { get; init; }

    public double TotalBudget { get; private set; }

    public void UpdateBudget(double newBudget) => TotalBudget = newBudget;
}
