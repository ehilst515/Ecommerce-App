﻿using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public async Task<Product> Delete(long? id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Details(long? id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll(int perPage, int pageIndex)
        {
            if (perPage < 1)
                throw new ArgumentOutOfRangeException(nameof(perPage), "must be positive.");

            if (pageIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "must be non-negative.");

            return await _context.Products
                .Skip(pageIndex * perPage)
                .Take(perPage)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToListAsync();
        }

        public Task GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetProductsCount()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return product;
        }


        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
