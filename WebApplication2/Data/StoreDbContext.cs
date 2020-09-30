using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
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
                    new Product { Id = 1, Name = "Lamp", Manuf = "Google", Price = 20.00M }
                );

            // SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            // SeedRole(modelBuilder, "Editor", "create", "update");
            // SeedRole(modelBuilder, "User");
        }
        public DbSet<Product> Products { get; set; }
    }
}
