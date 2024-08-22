using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Products
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime DateAdded { get; set; }
}
