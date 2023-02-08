using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Login : ComponentBase, IDisposable
{
    private User _user = new();

    private Person _person = new()
    {
        Address = new()
        {
            Id = Guid.NewGuid().ToString()
        }
    };

    private bool _signingUp = false;

    private string? _errorMessage = null;

    [Inject] IPersonRepository _personRepository { get; set; } = default!;

    [Inject] IUserService _userService { get; set; } = default!;

    private async Task Register()
    {
        Person person = await _personRepository.CreateAsync(_person);

        _user.PersonId = person.Id;

        await _userService.CreateAccountAsync(_user);

        _person = new();
        _user = new();

        _signingUp = false;
    }

    private async Task SignIn()
    {
        bool loginState = await _userService.Login(_user.Username, _user.Password);

        if (!loginState)
        {
            _errorMessage = "Invalid username or password";
        }
        else
        {
            _errorMessage = null;
        }
    }

    public void Dispose()
    {
        _errorMessage = null;
    }
}
