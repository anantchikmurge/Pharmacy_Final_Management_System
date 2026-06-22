namespace PharmacyManagementSystem.Models;

public class Drug
{
    public int Id { get; set; }
    public required string DrugName { get; set; }
    public required string DrugCode { get; set; }
    public required string Manufacturer { get; set; }
    public required string Category { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? Description { get; set; }
}