using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class VoteContext : DbContext
{
	public VoteContext() { }

	public DbSet<Vote> Votes { get; set; }
}
