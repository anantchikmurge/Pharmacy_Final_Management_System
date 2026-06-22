namespace PharmacyManagementSystem.DTO
{
    public class PaymentDto
    {
        public required string OrderReference { get; set; }
        public decimal Amount { get; set; }
    }
}