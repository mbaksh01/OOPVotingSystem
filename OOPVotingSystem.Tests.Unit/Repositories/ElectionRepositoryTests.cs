using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Tests.Unit.Repositories;

public class ElectionRepositoryTests
{
    private readonly Database _database;

    public ElectionRepositoryTests()
    {
        var builder = new DbContextOptionsBuilder<Database>();

        builder.UseInMemoryDatabase("testdb");

        _database = new Database(builder.Options);
    }

    private Election GetTestElection()
    {
        return new Election
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test",
            Country = "United Kingdom",
            Year = 2022
        };
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyCreatesElection()
    {
        // Arrange
        IElectionRepository sut = new ElectionRepository(_database);

        Election election = GetTestElection();

        // Act
        Election response = await sut.CreateAsync(election);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(election.Id, response.Id);
        Assert.Equal("Test", response.Name);
        Assert.Equal(1, _database.Elections.Count());
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyUpdateElection()
    {
        // Assert
        Election election = GetTestElection();

        _ = await _database.Elections.AddAsync(election);

        _ = await _database.SaveChangesAsync();

        IElectionRepository sut = new ElectionRepository(_database);

        election.Name = "Modified Election";

        // Act
        await sut.UpdateAsync(election.Id, election);

        // Assert
        Election? updatedElection = await _database.Elections.FindAsync(election.Id);

        Assert.NotNull(updatedElection);
        Assert.Equal(election.Id, updatedElection!.Id);
        Assert.Equal("Modified Election", updatedElection.Name);
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyDeleteElection()
    {
        // Arrange
        Election election = GetTestElection();

        _ = await _database.Elections.AddAsync(election);

        _ = await _database.SaveChangesAsync();

        IElectionRepository sut = new ElectionRepository(_database);

        // Act
        await sut.DeleteAsync(election.Id);

        // Assert
        Election? deletedElection = await _database.Elections.FindAsync(election.Id);

        Assert.Null(deletedElection);
    }
}
