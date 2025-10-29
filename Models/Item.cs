using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartApp.Models;

public class Item
{
    public int Id { get; set; }
    [Required, Display(Name = "Name")]
    public string? Name { get; set; }

    [Required, Range(1, 100, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    [Required, Column(TypeName = "decimal(18,2)"), Range(0.01, 10000.00, ErrorMessage = "Price cannot be zero.")]
    public decimal Price { get; set; }

    // Reference to Product
    // Foreign key to Product
    [Display(Name = "Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
