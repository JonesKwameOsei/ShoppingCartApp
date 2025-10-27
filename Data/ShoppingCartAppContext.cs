using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Data
{
    public class ShoppingCartAppContext : DbContext
    {
        public ShoppingCartAppContext (DbContextOptions<ShoppingCartAppContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingCartApp.Models.Product> Product { get; set; } = default!;
        public DbSet<ShoppingCartApp.Models.Item> Item { get; set; } = default!;
    }
}
