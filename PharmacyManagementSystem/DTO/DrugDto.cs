using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

// Used for creating or updating drug information
public class DrugDto
{
    [Required]
    public required string DrugName { get; set; }

    [Required]
    public required string DrugCode { get; set; }

    [Required]
    public required string Manufacturer { get; set; }

    [Required]
    public required string Category { get; set; }

    [Range(0.1, 10000)]
    public decimal Price { get; set; }

    [Range(0, 100000)]
    public int QuantityInStock { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    public string? Description { get; set; }
}