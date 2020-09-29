using ECommerceApp.Models;
using System;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public interface ICerealRepository
    {
        List<Cereal> GetCereals(string sortBy);
    }

}
