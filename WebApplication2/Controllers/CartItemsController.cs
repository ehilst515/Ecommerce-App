using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;
using ECommerceApp.Models.Cart;
using Microsoft.AspNetCore.Identity;
using ECommerceApp.Models.Identity;

namespace ECommerceApp.Controllers
{
    public class CartItemsController : Controller
    {
        private readonly StoreDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public CartItemsController(StoreDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }

        // GET: CartItems
        public async Task<IActionResult> Index()
        {
            var storeDbContext = _context.CartItems.Include(c => c.Product).Include(c => c.User);
            return View(await storeDbContext.ToListAsync());
        }

        // POST: CartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int qty, int productId)
        {
            var userId = userManager.GetUserId(User);

            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(c =>
                    c.ProductId == productId &&
                    c.UserId == userId
                );

            if (existingCartItem == null)
            {
                var item = new CartItem()
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = qty,
                };
                _context.CartItems.Add(item);
            }
            else
            {
                existingCartItem.Quantity += qty;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
