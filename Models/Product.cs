using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Product
{
    public int ProductId { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public List<Order> Orders { get; set; }
    public int SellerId { get; set; }

}
