using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using server.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

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
        public DbSet<WorkExperience> WorkExperience {get;set;}
        public DbSet<Language> Language { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<Tag> Tag { get; set; }

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
            builder.Entity<CV>()
                .HasMany(c => c.Educations)
                .WithOne(e => e.Cv)
                .HasForeignKey(e => e.CvId);

            builder.Entity<CV>()
                .HasMany(c => c.WorkExperiences)
                .WithOne(we => we.Cv)
                .HasForeignKey(we => we.CvId);

            builder.Entity<CV>()
                .HasMany(c => c.Languages)
                .WithOne(l => l.Cv)
                .HasForeignKey(l => l.CvId);
                
            builder.Entity<JobOffer>()
                .Property(j => j.Tags)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                );
        }
    }
}
