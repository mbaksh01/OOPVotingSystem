using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Service;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _repository;

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

    public UserService(ILogger<UserService> logger, IUserRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public Task<User> CreateAsync(User user)
        => _repository.CreateAsync(user);

    public Task<bool> ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return Task.FromResult(false);
        }

        return _repository.ValidateUsername(username);
    }

    public Task VerifyUser()
    {
        if (CurrentUser is null)
        {
            throw new InvalidOperationException($"{nameof(CurrentUser)} can not be null.");
        }

        return _repository.VerifyAccount(CurrentUser);
    }

    public async Task<bool> Login(string username, string password)
    {
        try
        {
            User user = await _repository.GetUserByUsername(username);

            if (user.Password != password)
            {
                throw new Exception("The provided password was not valid.");
            }

            CurrentUser = user;

            return true;
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "An error occurred trying to log a user in.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred trying to log a user in.");
        }

        return false;
    }

    public void Logout() => CurrentUser = null;
}
