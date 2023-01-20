namespace OOPVotingSystem.Models;

public class Costs
{
    public string PartyId { get; init; }

    public string ElectionId { get; init; }

    public double TotalCost { get; set; }

    public void UpdateBudget(double newCost) => TotalCost = newCost;
}
