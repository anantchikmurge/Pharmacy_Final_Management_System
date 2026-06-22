using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;

namespace PharmacyManagementSystem.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<string> CreatePaymentAsync(PaymentDto paymentDto)
        {
            await Task.Delay(1000);

            return $"Payment of ₹{paymentDto.Amount} completed successfully for Order {paymentDto.OrderReference}";
        }
    }
}