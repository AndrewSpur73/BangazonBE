﻿using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Users
{
    public int Id { get; set; }
    [Required]
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public bool? Seller { get; set; }
}
