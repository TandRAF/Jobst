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
        :base(dbContextOptions)
        {

        }
        public DbSet<CV> CV {get; set;}
        public DbSet<Education> Education {get;set;}
        public DbSet<UserProfile> UserProfile {get;set;}
        public DbSet<CompanyProfile> CompanyProfile {get;set;}
        public DbSet<WorkExperience> WorkExperiences {get;set;}
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define roles
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
            builder.Entity<UserProfile>()
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId) 
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CV>()
                .HasOne(cv => cv.UserProfile)
                .WithMany(up => up.Cvs)
                .HasForeignKey(cv => cv.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade); 
            builder.Entity<UserProfile>()
                .HasMany(up => up.Cvs)
                .WithOne(cv => cv.UserProfile)
                .HasForeignKey(cv => cv.UserProfileId);
            builder.Entity<CompanyProfile>()
                .HasOne(c => c.User) 
                .WithMany() 
                .HasForeignKey(c => c.UserId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
