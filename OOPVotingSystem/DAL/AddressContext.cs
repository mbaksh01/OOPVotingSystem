using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class AddressContext : DbContext
{
    public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }

    public DbSet<Address> Addresses { get; set; }
}
