using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

// Used when registering a new user
public class RegisterDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }

    [Required]
    public required string FullName { get; set; }

    [Required]
    public required string Role { get; set; }
}