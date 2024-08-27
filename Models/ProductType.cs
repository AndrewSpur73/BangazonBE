using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; }
    }
}