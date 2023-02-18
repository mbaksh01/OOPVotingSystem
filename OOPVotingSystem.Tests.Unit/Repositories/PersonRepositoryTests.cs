using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Tests.Unit.Repositories;

public class PersonRepositoryTests
{
    private readonly Database _database;

    public PersonRepositoryTests()
    {
        var builder = new DbContextOptionsBuilder<Database>();

        builder.UseInMemoryDatabase("testdb");

        _database = new Database(builder.Options);
    }

    private Person GetTestPerson()
    {
        return new Person
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test",
            Address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                Street1 = "B-town",
                Country = "United Kingdom",
                City = "Bristol",
                PostalCode = "BT12 3SN",
            },
            UniquePersonIdentifier = Guid.NewGuid().ToString(),
        };
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyCreatesPerson()
    {
        // Arrange
        IPersonRepository sut = new PersonRepository(_database);

        Person person = GetTestPerson();

        // Act
        Person response = await sut.CreateAsync(person);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(person.Id, response.Id);
        Assert.Equal("Test", response.Name);
        Assert.Equal(1, _database.People.Count());
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyUpdatePerson()
    {
        // Assert
        Person person = GetTestPerson();

        _ = await _database.People.AddAsync(person);

        _ = await _database.SaveChangesAsync();

        IPersonRepository sut = new PersonRepository(_database);

        person.Name = "Modified Person";

        // Act
        await sut.UpdateAsync(person.Id, person);

        // Assert
        Person? updatedPerson = await _database.People.FindAsync(person.Id);

        Assert.NotNull(updatedPerson);
        Assert.Equal(person.Id, updatedPerson!.Id);
        Assert.Equal("Modified Person", updatedPerson.Name);
    }

    [Fact]
    public async Task RepositoryShouldSuccessfullyDeletePerson()
    {
        // Arrange
        Person person = GetTestPerson();

        _ = await _database.People.AddAsync(person);

        _ = await _database.SaveChangesAsync();

        IPersonRepository sut = new PersonRepository(_database);

        // Act
        await sut.DeleteAsync(person.Id);

        // Assert
        Person? deletedPerson = await _database.People.FindAsync(person.Id);

        Assert.Null(deletedPerson);
    }
}
