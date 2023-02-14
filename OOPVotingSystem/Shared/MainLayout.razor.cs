using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Shared;

public partial class MainLayout
{
    [Inject] IUserService _userService { get; set; } = default!;

    protected override void OnInitialized()
    {
        _userService.CurrentUserChanged = _ => StateHasChanged();

        base.OnInitialized();
    }

    private string GetTimeOfDay()
    {
        return DateTime.UtcNow.Hour switch
        {
            >= 7 and < 12 => "Morning",
            >= 12 and < 17 => "Afternoon",
            >= 17 and < 21 => "Evening",
            _ => "Hello",
        };
    }
}
