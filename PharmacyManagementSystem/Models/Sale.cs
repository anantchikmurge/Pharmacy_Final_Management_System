// Represents completed sales used for reporting
namespace PharmacyManagementSystem.Models;
public class Sale
{
    public int Id { get; set; }
    public required string OrderReference { get; set; }
    public required string DoctorId { get; set; }
    public required string DrugCode { get; set; }
    public int QuantitySold { get; set; }
    public decimal SaleAmount { get; set; }
    public DateTime SaleDate { get; set; }
}