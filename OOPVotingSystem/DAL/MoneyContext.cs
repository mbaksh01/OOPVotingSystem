using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.Models;

namespace OOPVotingSystem.DAL;

public class MoneyContext : DbContext
{
	public MoneyContext(DbContextOptions<MoneyContext> options) : base(options) { }

	public DbSet<Budget> Budgets { get; set; }

	public DbSet<Costs> Costs { get; set; }
}
