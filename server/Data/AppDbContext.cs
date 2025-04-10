namespace server.Data
{
    using Microsoft.EntityFrameworkCore;
    using server.Models;  // Correct namespace for your User model

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
