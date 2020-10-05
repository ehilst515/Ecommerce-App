using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public class StoreDbContext : IdentityDbContext<ApplicationUser>
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

            // SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            // SeedRole(modelBuilder, "Editor", "create", "update");
            // SeedRole(modelBuilder, "User");
        }
        public DbSet<Product> Products { get; set; }
    }
}
