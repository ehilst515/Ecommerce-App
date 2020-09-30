using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _context;

        public StoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Delete(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return null;
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public Task GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
