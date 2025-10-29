using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Data;

public class ShoppingCartAppContext : DbContext
{
    public ShoppingCartAppContext (DbContextOptions<ShoppingCartAppContext> options)
        : base(options)
    {
    }

    public DbSet<ShoppingCartApp.Models.Product> Products { get; set; } = default!;
    public DbSet<ShoppingCartApp.Models.Item> Items { get; set; } = default!;
}
