using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace JobPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Job { get; set; }
        public DbSet<UserJob> UserJob { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserJob>(e => e.HasNoKey());


            // Override default AspNet Identity table names
            modelBuilder.Entity<IdentityUser>(entity => { entity.ToTable(name: "Users").Property(x => x.Id).HasColumnName("UserId"); });
            modelBuilder.Entity<IdentityRole>(entity => 
            {
                
                entity.ToTable(name: "Roles").Property(x => x.Id).HasColumnName("RoleId");
                //entity.HasData(new IdentityRole()
                //{
                //    Id = "1",
                //    Name = "Employer"
                //}, new IdentityRole() { Id = "2", Name = "Applicant" });


            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => 
            { 
                entity.ToTable("UserRoles");
                //entity.HasData(new IdentityUserRole<string>() { RoleId = "1", UserId = "df6c29e1-4c3a-457a-a5d4-f9af03f7fb94" }, new IdentityUserRole<string>()
                //{
                //    RoleId = "2",
                //    UserId = "c4b40680-1783-4eaa-9467-76b347e4b061"
                //});
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
                entity.Property(x => x.Id).HasColumnName("UserId");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
                entity.Property(x => x.Id).HasColumnName("RoleId");
            });




        }
    }
}
