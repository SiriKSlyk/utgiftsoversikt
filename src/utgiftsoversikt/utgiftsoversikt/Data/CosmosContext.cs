using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Data;

public class CosmosContext(DbContextOptions options) : DbContext(options)
{
<<<<<<< HEAD
    public DbSet<Models.User>? Users { get; set; }
    public DbSet<Models.Expense>? Expense { get; set; }
    public DbSet<Models.Month>? Month { get; set; }
    public DbSet<Models.Budget>? Budget { get; set; }
=======
    public DbSet<User>? Users { get; set; }
    public DbSet<Expense>? Expenses { get; set; }
    public DbSet<Month>? Month { get; set; }
    public DbSet<Budget>? Budget { get; set; }
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
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
