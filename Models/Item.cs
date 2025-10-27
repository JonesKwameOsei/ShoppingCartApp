using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartApp.Models;

public class Item
{
    public int Id { get; set; }
    public string? name { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal price { get; set; }

    // Foreign key to Product
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
