using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class PartyContext : DbContext
{
	public PartyContext() { }

	public DbSet<Party> Parties { get; set; }
}
