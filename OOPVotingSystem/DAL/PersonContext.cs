using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class PersonContext : DbContext
{
	public PersonContext() { }

	public DbSet<Person> People { get; set; }
}
