using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public sealed class AddressRepository : IRepository<Address>
{
    private readonly AddressContext _addressContext;

    public AddressRepository(AddressContext addressContext)
    {
        _addressContext = addressContext;
    }

    public async Task<Address> CreateAsync(Address entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _addressContext.Addresses.AddAsync(entity);

        _ = await _addressContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        Address address = await _addressContext.Addresses.FindAsync(id)
            ?? throw new ArgumentException($"No address was associated with the id '{id}'.");
        
        _ = _addressContext.Addresses.Remove(address);

        _ = await _addressContext.SaveChangesAsync();
    }

    public Task<IEnumerable<Address>> GetAllAsync()
        => Task.FromResult(_addressContext.Addresses.AsEnumerable());
    
    public async Task<Address> GetByIdAsync(string id)
    {
        return
            await _addressContext.Addresses.FindAsync(id)
            ?? throw new ArgumentException($"No address was associated with the id '{id}'.");
    }

    public Task UpdateAsync(string id, Address entity)
    {
        _ = _addressContext.Addresses.Update(entity);

        return _addressContext.SaveChangesAsync();
    }
}
