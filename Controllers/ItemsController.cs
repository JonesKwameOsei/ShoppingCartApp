using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Data;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ShoppingCartAppContext _context;

        public ItemsController(ShoppingCartAppContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var shoppingCartAppContext = _context.Items.Include(i => i.Product);
            return View(await shoppingCartAppContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/GetProductDetails/5
        [HttpGet]  // ✅ FIXED: Removed duplicate [HttpGet]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(new { error = "Product not found" });
            }

            return Json(new
            {
                productName = product.ProductName,
                price = product.Price,
                productImage = product.ProductImage
            });
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            var item = new Item
            {
                Price = 0,
                Quantity = 1
            };
            return View(item);
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Price,ProductId")] Item item)
        {
            // Remove Product navigation property from ModelState to prevent validation errors
            ModelState.Remove(nameof(item.Product));

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();

                    // Add success message to TempData
                    TempData["SuccessMessage"] = $"Item '{item.Name}' has been added to cart successfully!";

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the error
                    ModelState.AddModelError("", $"Error saving item: {ex.Message}");
                }
            }

            // If we got here, something failed, re-display form with errors
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", item.ProductId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", item.ProductId);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Price,ProductId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            // Remove Product navigation property from ModelState
            ModelState.Remove(nameof(item.Product));

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"Item '{item.Name}' has been updated successfully!";

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", item.ProductId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Item has been removed from cart successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}