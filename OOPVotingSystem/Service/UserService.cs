using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Service;

public class UserService : IUserService
{
    private readonly Database _database;

    private User? _user;

    public User? CurrentUser
    {
        get => _user;
        set
        {
            _user = value;

            CurrentUserChanged?.Invoke(_user);
        }
    }

    public Action<User?>? CurrentUserChanged { get; set; }

    public UserService(Database database)
    {
        _database = database;
    }

    public async Task CreateAccountAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(nameof(user));

        if (string.IsNullOrEmpty(user.PersonId))
        {
            throw new InvalidOperationException(
                $"There is no person associated with this user. Set the {nameof(User.PersonId)} property and try again."
            );
        }

        _ = await _database.Users.AddAsync(user);

        _ = await _database.SaveChangesAsync();
    }

    public async Task<bool> Login(string username, string password)
    {
        User? user = await _database.Users.FindAsync(username);

        if (user == null)
        {
            return false;
        }

        if (user.Password != password)
        {
            return false;
        }

        CurrentUser = user;

        return true;
    }

    public void Logout() => CurrentUser = null;

    public bool CurrentUserIsAdmin()
        => CurrentUser is not null
        && CurrentUser.Username.ToLower().Contains("admin");
}
