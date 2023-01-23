using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class PartyContext : DbContext
{
	public PartyContext(DbContextOptions<PartyContext> options) : base(options) { }

    public DbSet<Party> Parties { get; set; }
}
