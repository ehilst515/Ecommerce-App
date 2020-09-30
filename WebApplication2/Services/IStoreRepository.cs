using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApp.Data
{
    public interface IStoreRepository
    {
        Task Create(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task GetById(long id);
        Task<Product> Update(Product product);
        Task<Product> Delete(long? id);
        Task<Product> Details(long? id);
    }
}
