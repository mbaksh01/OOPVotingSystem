using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Management
{
    private IEnumerable<Election> _elections = default!;

    private readonly Election _createElection = new();

    private readonly Election _updateElection = new();

    private Validations? _createElectionsValidations;

    private Validations? _updateElectionsValidations;

    private Validations? _createPartyValidations;

    private Validations? _updatePartyValidations;

    private IEnumerable<Party> _parties = default!;

    private string _deleteElectionId = string.Empty;

    private readonly Party _createParty = new()
    {
        OperationAddress = new()
        {
            Id = Guid.NewGuid().ToString(),
        },
    };

    private readonly Party _updateParty = new()
    {
        OperationAddress = new()
        {
            Id = Guid.NewGuid().ToString(),
        },
    };

    private string _deletePartyId = string.Empty;

    [Inject] IUserService UserService { get; set; } = default!;

    [Inject] NavigationManager NavigationManager { get; set; } = default!;

    [Inject] IElectionRepository ElectionRepository { get; set; } = default!;

    [Inject] IPartyService PartyService { get; set; } = default!;

    [Inject] IPartyRepository PartyRepository { get; set; } = default!;

    [Inject] ILogger<Management> Logger { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (UserService.CurrentUser is null)
        {
            NavigationManager.NavigateTo("/");
            return;
        }

        if (!UserService.CurrentUser.Username.ToLower().Contains("admin"))
        {
            NavigationManager.NavigateTo("/");
            return;
        }

        _elections = await ElectionRepository.GetAllAsync();
        _parties = await PartyService.GetAllPartiesAsync();

        await base.OnInitializedAsync();
    }

    private async Task CreateElection()
    {
        try
        {
            if (_createElectionsValidations is not null)
            {
                bool isValid = await _createElectionsValidations.ValidateAll();

                if (!isValid)
                {
                    return;
                }
            }

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
            if (_updateElectionsValidations is not null)
            {
                bool isValid = await _updateElectionsValidations.ValidateAll();

                if (!isValid)
                {
                    return;
                }
            }

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

    private async Task CreateParty()
    {
        try
        {
            _ = await PartyRepository.CreateAsync(_createParty);

            _parties = await PartyService.GetAllPartiesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{}", ex.Message);
        }
    }

    private async Task UpdateParty()
    {
        try
        {
            await PartyRepository.UpdateAsync(_updateParty.Id, _updateParty);

            _parties = await PartyService.GetAllPartiesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{}", ex.Message);
        }
    }

    private async Task DeleteParty()
    {
        try
        {
            await PartyRepository.DeleteAsync(_deletePartyId);

            _parties = await PartyService.GetAllPartiesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{}", ex.Message);
        }
    }
}
