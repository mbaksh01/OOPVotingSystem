using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public sealed partial class Account : IDisposable
{
    [Inject] IUserService UserService { get; set; } = default!;

    [Inject] NavigationManager NavigationManager { get; set; } = default!;

    private string? _verificationMessage;

    protected override Task OnInitializedAsync()
    {
        if (UserService.CurrentUser is null)
        {
            NavigationManager.NavigateTo("/");
            return Task.CompletedTask;
        }

        if (UserService.CurrentUser.Username.ToLower().Contains("admin"))
        {
            NavigationManager.NavigateTo("/");
            return Task.CompletedTask;
        }

        return base.OnInitializedAsync();
    }

    private Task ValidateAccount() => UserService.VerifyUser();

    public void Dispose()
    {
        _verificationMessage = null;
    }
}
