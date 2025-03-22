using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SFT.Models;
public class User
{
    [Key]
    public int UserID { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; } // Secure hashed password
}

