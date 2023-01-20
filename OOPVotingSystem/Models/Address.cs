namespace OOPVotingSystem.Models;

public class Address
{
    public string Street1 { get; set; } = default!;

    public string? Street2 { get; set; }

    public string City { get; set; } = default!; 

    public string? State { get; set; }

    public string PostalCode { get; set; } = default!;

    public string Country { get; set; } = default!;
}
