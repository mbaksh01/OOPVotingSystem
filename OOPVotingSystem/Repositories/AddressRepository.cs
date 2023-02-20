using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;

namespace OOPVotingSystem.Repositories;

public class AddressRepository : IRepository<Address>
{
    private readonly Database _database;

    public AddressRepository(Database database)
    {
        _database = database;
    }

    public Task<Address> CreateAsync(Address entity) => throw new NotImplementedException();
    
    public Task DeleteAsync(string id) => throw new NotImplementedException();

    public Task<IEnumerable<Address>> GetAllAsync()
        => Task.FromResult<IEnumerable<Address>>(_database.Addresses);
    
    public Task<Address> GetByIdAsync(string id) => throw new NotImplementedException();
    
    public Task UpdateAsync(string id, Address entity) => throw new NotImplementedException();
}
