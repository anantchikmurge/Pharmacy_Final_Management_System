using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;

namespace PharmacyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentDto paymentDto)
        {
            var result = await _paymentService.CreatePaymentAsync(paymentDto);

            return Ok(result);
        }
    }
}