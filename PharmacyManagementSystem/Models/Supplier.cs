// Represents a supplier who provides drugs
public class Supplier
{
    public int Id { get; set; }
    public required string SupplierName { get; set; }
    public required string ContactPerson { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
}