using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class PersonContext : DbContext
{
	public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    public DbSet<Person> People { get; set; }
}
