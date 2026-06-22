using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

// Represents a drug item inside an order
public class OrderItemDto
{
    [Required]
    public int DrugId { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }
}