namespace OOPVotingSystem.Models;

public class Election
{
    public string Id { get; set; } = default!;

    public string County { get; set; } = default!;

    public int Year { get; set; } = DateTime.UtcNow.Year;
}
