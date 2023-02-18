using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Repositories;
using OOPVotingSystem.DAL;

namespace OOPVotingSystem.Tests.Unit.Repositories;

public class PartyRepositoryTests
{
    private readonly Database _database;

    public PartyRepositoryTests()
    {
        var builder = new DbContextOptionsBuilder<Database>();

        builder.UseInMemoryDatabase("testdb");

        _database = new Database(builder.Options);
    }

    private Party GetTestParty()
    {
        return new Party
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test",
            OperationAddress = new Address
            {
                Id = Guid.NewGuid().ToString(),
                Street1 = "B-town",
                Country = "United Kingdom",
                City = "Bristol",
                PostalCode = "BT12 3SN",
            }
        };
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyCreatesParty()
    {
        // Arrange
        IPartyRepository sut = new PartyRepository(_database);

        Party party = GetTestParty();

        // Act
        Party response = await sut.CreateAsync(party);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(party.Id, response.Id);
        Assert.Equal("Test", response.Name);
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyUpdateParty()
    {
        // Assert
        Party party = GetTestParty();

        _ = await _database.Parties.AddAsync(party);

        _ = await _database.SaveChangesAsync();

        IPartyRepository sut = new PartyRepository(_database);

        party.Name = "Modified Party";

        // Act
        await sut.UpdateAsync(party.Id, party);

        // Assert
        Party? updatedParty = await _database.Parties.FindAsync(party.Id);

        Assert.NotNull(updatedParty);
        Assert.Equal(party.Id, updatedParty!.Id);
        Assert.Equal(1, _database.Parties.Count());
        Assert.Equal("Modified Party", updatedParty.Name);
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyDeleteParty()
    {
        // Arrange
        Party party = GetTestParty();

        _ = await _database.Parties.AddAsync(party);

        _ = await _database.SaveChangesAsync();

        IPartyRepository sut = new PartyRepository(_database);

        // Act
        await sut.DeleteAsync(party.Id);

        // Assert
        Party? deletedParty = await _database.Parties.FindAsync(party.Id);

        Assert.Null(deletedParty);
    }
}
