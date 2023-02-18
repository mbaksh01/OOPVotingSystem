using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

    private void DisplaySignIn()
    {
        _errorMessage = null;

        _user = new()
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

        _signingUp = false;
    }

    private void DisplaySignUp()
    {
        _errorMessage = null;

        _user = new()
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

        _signingUp = true;
    }

    private async Task CheckIfUsernameExists(ValidatorEventArgs args, CancellationToken cancellationToken)
    {
        string? username = args.Value as string;

        if (string.IsNullOrEmpty(username))
        {
            args.Status = ValidationStatus.Error;
            return;
        }

        bool valid = await _userService.ValidateUsername(username);

        if (valid)
        {
            args.Status = ValidationStatus.Success;
            return;
        }

        args.Status = ValidationStatus.Error;
        args.ErrorText = "This username is taken.";
    }

    private async Task Register()
    {
        _user.PersonId = _user.Person.Id;

        await _userService.CreateAsync(_user);

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

    private Task OnEnterLogin(KeyboardEventArgs args)
    {
        if (args.Key == "Enter")
        {
            return SignIn();
        }

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _errorMessage = null;
    }
}
