using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Order
{
    public int OrderId { get; set; }
    [Required]
    public string Uid { get; set; }
    [Required]
    public bool OrderComplete { get; set; }
    public int? PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }

    public List<Product>? Products { get; set; }
}
