using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Management
{
    private IEnumerable<Election> _elections = default!;

    private readonly Election _createElection = new();

    private readonly Election _updateElection = new();

    private string _deleteElectionId = string.Empty;

    private readonly Party _createParty = new();

    [Inject] IUserService UserService { get; set; } = default!;

    [Inject] NavigationManager NavigationManager { get; set; } = default!;

    [Inject] IElectionRepository ElectionRepository { get; set; } = default!;

    [Inject] ILogger<Management> Logger { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (UserService.CurrentUser is null)
        {
            NavigationManager.NavigateTo("/");
        }

        if (!UserService.CurrentUser!.Username.ToLower().Contains("admin"))
        {
            NavigationManager.NavigateTo("/");
        }

        _elections = await ElectionRepository.GetAllAsync();

        await base.OnInitializedAsync();
    }

    private async Task CreateElection()
    {
        try
        {
            _ = await ElectionRepository.CreateAsync(_createElection);

            _elections = await ElectionRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{}", ex.Message);
        }
    }

    private async Task UpdateElection()
    {
        try
        {
            await ElectionRepository.UpdateAsync(
                _updateElection.Id, 
                _updateElection
            );

            _elections = await ElectionRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{}", ex.Message);
        }
    }

    private async Task DeleteElection()
    {
        try
        {
            await ElectionRepository.DeleteAsync(_deleteElectionId);

            _elections = await ElectionRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{}", ex.Message);
        }
    }
}
