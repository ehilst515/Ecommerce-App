using System.Collections.Generic;
using ECommerceApp.Models;

namespace ECommerceApp.Data
{
    public interface ICerealRepository
    {
        List<Cereal> GetCereals(string sortBy);
    }
}