// Represents an order placed by a doctor
namespace PharmacyManagementSystem.Models;
public class Order
{
    public int Id { get; set; }
    // Unique order reference
    public required string OrderReference { get; set; }
    // Doctor who placed the order
    public required string DoctorId { get; set; }
    public decimal TotalAmount { get; set; }
    // Order status (Pending / Verified / PickedUp)
    public required string Status { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? VerifiedOn { get; set; }
    public DateTime? PickedUpOn { get; set; }
    // Drugs included in this order
    public List<OrderItem>? Items { get; set; }
}