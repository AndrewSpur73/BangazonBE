using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Users
{
    public int Id { get; set; }
    [Required]
    public bool OrderStatus { get; set; }
    public string? PaymentType { get; set; }
    public decimal Total { get; set; }
    public DateOnly OrderDate { get; set; }
}
