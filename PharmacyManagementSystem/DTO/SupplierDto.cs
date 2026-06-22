using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

// Used for creating or updating supplier information
public class SupplierDto
{
    [Required]
    public required string SupplierName { get; set; }

    [Required]
    public required string ContactPerson { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [Phone]
    public required string Phone { get; set; }

    [Required]
    public required string Address { get; set; }
}