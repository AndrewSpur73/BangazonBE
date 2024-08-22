using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Product
{
    public int ProductId { get; set; }
    [Required]
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime DateAdded { get; set; }
    public string? ImageUrl { get; set; }
  
}
