using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Election> Elections { get; set; }

    public DbSet<Party> Parties { get; set; }

    public DbSet<Person> People { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Vote> Votes { get; set; }
}
