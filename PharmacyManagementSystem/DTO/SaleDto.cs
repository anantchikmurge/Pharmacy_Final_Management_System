using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

public class SaleDto
{
    [Required]
    public required string OrderReference { get; set; }

    [Required]
    public required string DoctorId { get; set; }

    [Required]
    public required string DrugCode { get; set; }

    [Range(1,1000)]
    public int QuantitySold { get; set; }

    [Range(0.1,100000)]
    public decimal SaleAmount { get; set; }

    public DateTime SaleDate { get; set; }
}