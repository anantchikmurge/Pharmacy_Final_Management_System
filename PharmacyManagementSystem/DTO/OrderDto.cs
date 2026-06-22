using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO;

// Used when a doctor places an order
public class OrderDto
{
    [Required]
    public required string DoctorId { get; set; }

    [Required]
    public required List<OrderItemDto>? Items { get; set; }
}