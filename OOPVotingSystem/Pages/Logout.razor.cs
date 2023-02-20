using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public sealed partial class Logout
{
    [Inject] IUserService UserService { get; set; } = default!;

    [Inject] NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        UserService.Logout();

        NavigationManager.NavigateTo("/");
    }
}
