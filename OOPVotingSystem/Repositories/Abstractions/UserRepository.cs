using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.Repositories.Abstractions;

public class UserRepository : IUserRepository
{
    private readonly Database _database;

    public UserRepository(Database database)
    {
        _database = database;
    }

    public async Task<User> CreateAsync(User entity)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        if (string.IsNullOrEmpty(entity.PersonId))
        {
            throw new InvalidOperationException(
                $"There is no person associated with this user. Set the {nameof(User.PersonId)} property and try again."
            );
        }

        _ = await _database.Users.AddAsync(entity);

        _ = await _database.SaveChangesAsync();

        return entity;
    }
    
    public async Task DeleteAsync(string id)
    {
        User user = await _database.Users.FindAsync(id)
            ?? throw new ArgumentException($"No user was associated with the id '{id}'.");

        _ = _database.Users.Remove(user);

        _ = await _database.SaveChangesAsync();
    }
    
    public Task<IEnumerable<User>> GetAllAsync()
        => Task.FromResult<IEnumerable<User>>(_database.Users);

    public async Task<User> GetByIdAsync(string id)
    {
        return
            await _database.Users.FindAsync(id)
            ?? throw new ArgumentException($"No user was associated with the id '{id}'.");
    }

    public Task<User> GetUserByUsername(string username)
    {
        User user = _database.Users.FirstOrDefault(t => t.Username == username)
                ?? throw new ArgumentException($"No user was associated with the username '{username}'.");

        return Task.FromResult(user);
    }

    public Task UpdateAsync(string id, User entity)
    {
        _ = _database.Users.Update(entity);

        return _database.SaveChangesAsync();
    }

    public async Task VerifyAccount(User entity)
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        entity.Person.Verified = true;

        _ = _database.Users.Update(entity);

        _ = await _database.SaveChangesAsync();
    }
}
