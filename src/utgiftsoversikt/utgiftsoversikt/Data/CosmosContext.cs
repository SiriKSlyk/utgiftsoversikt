using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Data;

public class CosmosContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.User>? Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.User>()
            .ToContainer("Users") // To container
            .HasPartitionKey(u => u.Id); // Partition key
    }
}
