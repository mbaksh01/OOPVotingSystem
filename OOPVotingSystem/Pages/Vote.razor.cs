using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Vote : ComponentBase
{
    [Inject] IPersonRepository PersonRepository { get; set; } = default!;

    [Inject] IUserService UserService { get; set; } = default!;

    [Inject] NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (UserService.CurrentUser is null)
        {
            NavigationManager.NavigateTo("/");
            return;
        }

        if (UserService.CurrentUser.Username.ToLower().Contains("admin"))
        {
            NavigationManager.NavigateTo("/");
            return;
        }

        await base.OnInitializedAsync();
    }

    private async Task Register()
    {
        if (UserService.CurrentUser is null)
        {
            return;
        }

        try
        {
            await PersonRepository.RegisterToVoteAsync(UserService.CurrentUser.PersonId);
        }
        catch (InvalidOperationException ex)
        {
            // Display ex to user.
        }
    }
}
