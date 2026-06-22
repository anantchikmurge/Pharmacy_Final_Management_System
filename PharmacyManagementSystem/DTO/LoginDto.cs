using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

// Used when a user logs into the system
public class LoginDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}