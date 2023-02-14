using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public sealed class AddressRepository : IRepository<Address>
{
    private readonly Database _database;

    public AddressRepository(Database database)
    {
        _database = database;
    }

    public async Task<Address> CreateAsync(Address entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _database.Addresses.AddAsync(entity);

        _ = await _database.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        Address address = await _database.Addresses.FindAsync(id)
            ?? throw new ArgumentException($"No address was associated with the id '{id}'.");
        
        _ = _database.Addresses.Remove(address);

        _ = await _database.SaveChangesAsync();
    }

    public Task<IEnumerable<Address>> GetAllAsync()
        => Task.FromResult<IEnumerable<Address>>(_database.Addresses);
    
    public async Task<Address> GetByIdAsync(string id)
    {
        return
            await _database.Addresses.FindAsync(id)
            ?? throw new ArgumentException($"No address was associated with the id '{id}'.");
    }

    public Task UpdateAsync(string id, Address entity)
    {
        _ = _database.Addresses.Update(entity);

        return _database.SaveChangesAsync();
    }
}
