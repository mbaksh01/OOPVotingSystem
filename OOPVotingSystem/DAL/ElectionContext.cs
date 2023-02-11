using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class ElectionContext : DbContext
{
    public ElectionContext(DbContextOptions<ElectionContext> options) : base(options) { }

    public DbSet<Election> Elections { get; set; }
}
