namespace OOPVotingSystem.Models;

public class Address
{
    public string Id { get; set; } = default!;

    public string Street1 { get; set; } = default!;

    public string? Street2 { get; set; }

    public string City { get; set; } = default!; 

    public string? State { get; set; }

    public string PostalCode { get; set; } = default!;

    public string Country { get; set; } = default!;

    public virtual List<Person> People { get; set; } = default!;
}
