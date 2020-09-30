using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Services
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
        }
        
        public DbSet<Product> Products { get; set; }
    }
}
