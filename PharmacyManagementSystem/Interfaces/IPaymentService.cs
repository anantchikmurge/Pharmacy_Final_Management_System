using PharmacyManagementSystem.DTO;

namespace PharmacyManagementSystem.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentAsync(PaymentDto paymentDto);
    }
}