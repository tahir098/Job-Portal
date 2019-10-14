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
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Override default AspNet Identity table names
            modelBuilder.Entity<IdentityUser>(entity => { entity.ToTable(name: "Users").Property(x => x.Id).HasColumnName("UserId"); });
            modelBuilder.Entity<IdentityRole>(entity => 
            {
                
                entity.ToTable(name: "Roles").Property(x => x.Id).HasColumnName("RoleId");
                entity.HasData(new IdentityRole()
                {
                    Id = "1",
                     Name = "Employer"                      
                },new IdentityRole() { Id="2",Name="Applicant" });


            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => 
            { 
                entity.ToTable("UserRoles");
                entity.HasData(new IdentityUserRole<string>() { RoleId = "1", UserId = "0d01af92-276f-4a51-85a5-574ca7e7f081" }, new IdentityUserRole<string>() 
                {
                      RoleId = "2", UserId = "a11491f4-02fe-43f1-86ec-25cc7d0b90de"
                });
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
