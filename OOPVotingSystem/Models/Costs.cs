using Microsoft.EntityFrameworkCore;

namespace OOPVotingSystem.Models;

[PrimaryKey(nameof(PartyId), nameof(ElectionId))]
public class Costs
{
    public string PartyId { get; set; } = default!;

    public string ElectionId { get; set; } = default!;

    public double TotalCost { get; set; }

    public virtual Party Party { get; set; } = default!;

    public virtual Election Election { get; set; } = default!;

    public void UpdateBudget(double newCost) => TotalCost = newCost;
}
