using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IStoreRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly StoreDbContext _context;

        public ProductsController(StoreDbContext context, IStoreRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? perPage, int? pageNum)
        {
            return View(await repository.GetAll(perPage ?? 12, pageNum ?? 0));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await repository.Details(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Products/Details/5 = Add to Cart
        public async Task<IActionResult> Details(long? id, int? quantity)
        {
            if (id == null) return NotFound();

            // TODO: Use a repository for this!
            _context.CartItems.Add(new Models.Cart.CartItem
            {
                ProductId = (long)id,
                UserId = userManager.GetUserId(User),
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sku,Name,Price,Description,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                await repository.Create(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Sku,Name,Price,Description,Image")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await repository.Update(product);

                return RedirectToAction(nameof(Index));

            }

            
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await repository.Delete(id));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
