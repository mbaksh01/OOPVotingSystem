namespace OOPVotingSystem.Models;

public class Person
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public Address Address { get; set; } = default!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string UniquePersonIdentifier { get; set; } = default!;

    public bool Verified { get; set; }

    public bool AcceptedTerms { get; set; }
}
