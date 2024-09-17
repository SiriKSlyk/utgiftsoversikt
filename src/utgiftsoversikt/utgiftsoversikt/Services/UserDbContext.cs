using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Services
{
    

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;


    }

}
