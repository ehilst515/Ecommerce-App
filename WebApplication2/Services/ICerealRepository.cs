using System.Collections.Generic;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface ICerealRepository
    {
        List<Cereal> GetCereals(string sortBy);
    }
}