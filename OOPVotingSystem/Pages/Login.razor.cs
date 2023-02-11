using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Models;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Login : ComponentBase, IDisposable
{
    private User _user = new()
    {
        Person = new()
        {
            Id = Guid.NewGuid().ToString(),

            Address = new()
            {
                Id = Guid.NewGuid().ToString(),
            }
        }
    };

    private bool _signingUp = false;

    private bool _justSignedUp = false;

    private string? _errorMessage = null;

    [Inject] IUserService _userService { get; set; } = default!;

    [Inject] NavigationManager _navigationManager { get; set; } = default!;

    private async Task Register()
    {
        _user.PersonId = _user.Person.Id;

        await _userService.CreateAccountAsync(_user);

        // _person = new();
        _user = new();

        _signingUp = false;
        _justSignedUp = true;
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
            _navigationManager.NavigateTo("/");
        }

        _justSignedUp = false;
    }

    public void Dispose()
    {
        _errorMessage = null;
    }
}
