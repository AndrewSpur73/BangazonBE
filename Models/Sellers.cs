using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Sellers
{
    public int Id { get; set; }
    [Required]
    public string? StoreName { get; set; }
    public string? Description { get; set; }
}
