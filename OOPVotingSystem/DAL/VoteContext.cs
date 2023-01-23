using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class VoteContext : DbContext
{
	public VoteContext(DbContextOptions<VoteContext> options) : base(options) { }

    public DbSet<Vote> Votes { get; set; }
}
