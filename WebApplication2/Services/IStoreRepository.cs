using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Services
{
    public interface IStoreRepository
    {
        Task Create(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task GetById(long id);
        Task Update(Product product);
        Task<Product> Delete(long id);
    }
}
