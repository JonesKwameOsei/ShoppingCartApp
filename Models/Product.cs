using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartApp.Models;

public class Product
{
    public int Id { get; set; }

    [Required, Display(Name = "Product Name")]
    public string? ProductName { get; set; }

    [Required, Column(TypeName = "decimal(18,2)"), Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Display(Name = "Product Image")]
    public string? ProductImage { get; set; }

    public ICollection<Item>? Items { get; set; } = new List<Item>();
}
