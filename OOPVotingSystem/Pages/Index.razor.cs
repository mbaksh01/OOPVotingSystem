using Microsoft.AspNetCore.Components;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Pages;

public partial class Index
{
    [Inject] IUserService UserService { get; set; } = default!;
}
