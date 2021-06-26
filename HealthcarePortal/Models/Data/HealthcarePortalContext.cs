using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.Data
{
    public class HealthcarePortalContext : DbContext
    {
        public HealthcarePortalContext() : base("name=HealthcarePortalDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Proposal> Proposals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Roles)
                        .WithMany(c => c.Users)
                        .Map(x =>
                        {
                            x.MapLeftKey("UserId");
                            x.MapRightKey("RoleId");
                            x.ToTable("UserRoles");
                        });
        }
    }
}