using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Uid { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required] 
    public string LastName { get; set; }
    [Required]
    public string? Address { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool? Seller { get; set; }
    public List<Order>? Orders { get; set; }
}
