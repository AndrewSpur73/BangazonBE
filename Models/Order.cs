using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Order
{
    public int OrderId { get; set; }
    [Required]
    public int UserId { get; set; }
    public bool OrderStatus { get; set; }
    public string? PaymentType { get; set; }
    public decimal Total { get; set; }
    public DateOnly OrderDate { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
}
