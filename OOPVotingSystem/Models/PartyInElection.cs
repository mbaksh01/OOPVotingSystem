namespace OOPVotingSystem.Models;

public class PartyInElection
{
    public string ElectionId { get; set; } = default!;

    public string PartId { get; set; } = default!;

    public virtual Election Election { get; set; } = default!;

    public virtual Party Party { get; set; } = default!;
}
