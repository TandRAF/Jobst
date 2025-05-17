using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using server.Model;
using Microsoft.AspNetCore.Identity;

namespace server.Data
{
    public class ApplicationDBContext : IdentityDbContext<UserBase>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        public DbSet<CV> CV { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Name = "Company",
            NormalizedName = "COMPANY"
        },
        new IdentityRole
        {
            Name = "User",
            NormalizedName = "USER"
        }
    };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
