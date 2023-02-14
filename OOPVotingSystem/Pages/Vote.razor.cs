using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Vote : ComponentBase
{
    private IEnumerable<Election> _elections = Enumerable.Empty<Election>();

    private IEnumerable<Party> _parties = Enumerable.Empty<Party>();

    private Election? _election;

    private Party? _party;

    private string? _castVoteMessage;

    [Inject] IVoteRepository VoteRepository { get; set; } = default!;

    [Inject] IPartyRepository PartyRepository { get; set; } = default!;

    [Inject] IElectionRepository ElectionRepository { get; set; } = default!;

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

        _elections = await ElectionRepository.GetAllAsync();
        _parties = await PartyRepository.GetAllAsync();

        await base.OnInitializedAsync();
    }

    private void SetSelectedElection(string electionId)
        => _election = _elections.First(t => t.Id == electionId);

    private void SetSelectedParty(string partyId)
        => _party = _parties.First(t => t.Id == partyId);

    private async Task CastVote()
    {
        if (_election is null)
        {
            _castVoteMessage = "You have to select and election to vote.";
            return;
        }

        if (_party is null)
        {
            _castVoteMessage = "You have to select a party to vote.";
            return;
        }

        _ = await VoteRepository.CreateAsync(new(
            candidateId: string.Empty,
            _election.Id,
            _party.Id
        ));

        _castVoteMessage = 
            $"You have successfully cast your vote the party: {_party.Name} in the election: {_election.Name}.";
    }
}
