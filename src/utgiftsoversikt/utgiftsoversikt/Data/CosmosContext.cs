using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Data;

public class CosmosContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.User>? Users { get; set; }
    public DbSet<Models.Expense>? Expenses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.User>()
            .ToContainer("Users") // To container
            .HasPartitionKey(u => u.Id); // Partition key

        modelBuilder.Entity<Models.Expense>()
            .ToContainer("Expenses") // To container
            .HasPartitionKey(u => u.Id); // Partition key
    }
}
