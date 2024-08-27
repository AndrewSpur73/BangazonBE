using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Required]
        public string? Category { get; set; }
        public List<Order>? Orders { get; set; }
    }
}