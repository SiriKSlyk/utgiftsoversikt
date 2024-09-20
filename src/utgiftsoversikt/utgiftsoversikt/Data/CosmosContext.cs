using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Data;

public class CosmosContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.User>? Users { get; set; }
    public DbSet<Models.Expense>? Expense { get; set; }
    public DbSet<Models.Month>? Month { get; set; }
    public DbSet<Models.Budget>? Budget { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.User>()
            .ToContainer("Users") // To container
            .HasPartitionKey(u => u.Id); // Partition key

        modelBuilder.Entity<Expense>()
            .ToContainer("Expenses") // To container
            .HasPartitionKey(e => e.Id); // Partition key

        modelBuilder.Entity<Budget>()
            .ToContainer("Budgets") // To container
            .HasPartitionKey(b => b.Id); // Partition key

        modelBuilder.Entity<Month>()
            .ToContainer("Months") // To container
            .HasPartitionKey(m => m.Id); // Partition key
    }
}
