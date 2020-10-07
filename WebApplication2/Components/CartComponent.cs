using ECommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Components
{
    public class CartComponent : ViewComponent
    {
        private readonly Data.StoreDbContext storeDb;

        public CartComponent(StoreDbContext storeDb)
        {
            this.storeDb = storeDb;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var cartItemsCount = await storeDb.CartItems
        //        .Where(i => i.UserId == User.Identity.Name);

        //    return View(new CartViewModel { CartCount = cartItemsCount });
        //}
    }

    public class CartViewModel
    {
        public int CartCount { get; set; }
    }
}
