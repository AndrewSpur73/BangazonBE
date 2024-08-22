using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    [Required]
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
    public Order? Order { get; set; }
    public Product? Product { get; set; }

}
