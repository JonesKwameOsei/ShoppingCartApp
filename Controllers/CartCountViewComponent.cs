using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartApp.Controllers;

public class CartCountViewComponent : ViewComponent
{
    private readonly CartService _cartService;

    public CartCountViewComponent(CartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = User?.Identity?.Name;
        int count = await _cartService.GetCartItemCountAsync(userId);
        return View("Default", count);
    }
}

public class CartService
{
    private readonly ShoppingCartAppContext _context;

    public CartService(ShoppingCartAppContext context)
    {
        _context = context;
    }

    public async Task<int> GetCartItemCountAsync(string? userId = null)
    {
        var query = _context.Items.AsQueryable();
        
        // If user-specific cart tracking is needed, filter by userId
        // For now, returning total count as per original implementation
        
        return await query.CountAsync();
    }

    public async Task<int> GetCartItemQuantityTotalAsync(string? userId = null)
    {
        var query = _context.Items.AsQueryable();
        
        // Sum up quantities instead of just counting items
        return await query.SumAsync(item => item.Quantity);
    }
}