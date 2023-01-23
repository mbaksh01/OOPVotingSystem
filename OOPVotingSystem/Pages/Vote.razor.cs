using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Vote : ComponentBase
{
    [Inject] IVoteRepository _voteRepository { get; set; } = default!;

    [Inject] IPersonRepository _personRepository { get; set; } = default!;

    [Inject] IUserService _userService { get; set; } = default!;

    private async Task Register()
    {
        if (_userService.CurrentUser is null)
        {
            return;
        }

        try
        {
            await _personRepository.RegisterToVoteAsync(_userService.CurrentUser.PersonId);
        }
        catch (InvalidOperationException ex)
        {
            // Display ex to user.
        }
    }
}
