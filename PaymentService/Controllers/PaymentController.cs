using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PaymentService.Models;
using PaymentService.Services;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public PaymentController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpPost("MakePayment")]
        public async Task<IActionResult> MakePayment([FromBody] PaymentRequest request)
        {

            try
            {
                bool isPaymentSuccessful = true;

                var payment = new Payment
                {
                    PaymentId = Guid.NewGuid(),
                    BillId = request.BillId,
                    UserId = request.UserId,
                    Amount = request.Amount,
                    PaymentDate = DateTime.UtcNow,
                    CardDetails = new CardDetails
                    {
                        CardNumber = MaskCardNumber(request.CardDetails.CardNumber),
                        CardHolder = request.CardDetails.CardHolder,
                        ExpiryDate = request.CardDetails.ExpiryDate
                    },
                    IsSuccessful = isPaymentSuccessful
                };

                await _mongoDbService.SavePaymentAsync(payment);

                // Log için
                Console.WriteLine($"Payment saved: {payment.PaymentId}");

                return Ok(new { Success = isPaymentSuccessful });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, new { Success = false, Message = "Internal Server Error" });
            }
        }

        private string MaskCardNumber(string cardNumber)
        {
            return "**** **** **** " + cardNumber.Substring(cardNumber.Length - 4);
        }
    }
}

