using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartApp.Models;

public class Item
{
    public int Id { get; set; }
    [Required, Display(Name = "Name")]
    public string? Name { get; set; }

    [Required, Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    // Foreign key to Product
    [Display(Name = "Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
