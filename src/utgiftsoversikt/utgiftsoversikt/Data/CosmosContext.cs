using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Data;

public class CosmosContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.User>? Users { get; set; }
    public DbSet<Models.UserExpenses>? UserExpenses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.User>()
            .ToContainer("Users") // To container
            .HasPartitionKey(u => u.Id); // Partition key

        modelBuilder.Entity<UserExpenses>()
            .ToContainer("UserExpenses") // To container
            .HasPartitionKey(e => e.Id); // Partition key

        /*modelBuilder.Entity<Shop>()
            .ToContainer("Shops") // To container
            .HasPartitionKey(s => s.Id); // Partition key*/

        //modelBuilder.Entity<Models.User>().OwnsMany(u => u.Expenses);
    }
}
