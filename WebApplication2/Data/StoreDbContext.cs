using System;
using System.Linq;
using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public class StoreDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Sku = "GOO001", Name = "Lamp by Google", Price = 300.00M, Description = "Google's new smart lamp", Image = "No Image" }
                );

            SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "create", "update");
            SeedRole(modelBuilder, "User");
        }

        public DbSet<Product> Products { get; set; }

        private int nextRoleClaimId = 1;

        private void SeedRole(ModelBuilder modelBuilder, string roleName = null, params string[] permissions)
        {
            var role = new ApplicationRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString(),
            };
            modelBuilder.Entity<ApplicationRole>()
                .HasData(role);

            var roleClaims = permissions
                .Select(permission =>
                    new IdentityRoleClaim<string>
                    {
                        Id = nextRoleClaimId++,
                        RoleId = role.Id,
                        ClaimType = "permissions",
                        ClaimValue = permission,
                    })
                .ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .HasData(roleClaims);
        }
    }
}