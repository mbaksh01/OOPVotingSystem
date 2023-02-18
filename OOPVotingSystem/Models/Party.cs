namespace OOPVotingSystem.Models;

public class Party
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public virtual Address OperationAddress { get; set; } = default!;

    public virtual List<Candidate> Candidates { get; set; } = new();
}
