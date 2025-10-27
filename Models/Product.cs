using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartApp.Models;

public class Product
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string? ProductImage { get; set; }
    public ICollection<Item>? Items { get; set; } = new List<Item>();
}
