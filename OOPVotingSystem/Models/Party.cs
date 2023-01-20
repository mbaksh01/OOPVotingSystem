namespace OOPVotingSystem.Models;

public class Party
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public Address OperationAddress { get; set; } = default!;

    public List<Budget> Budgets { get; set; } = new();
}
