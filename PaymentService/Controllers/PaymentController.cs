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

            return Ok(new { Success = isPaymentSuccessful });
        }

        private string MaskCardNumber(string cardNumber)
        {
            return "**** **** **** " + cardNumber.Substring(cardNumber.Length - 4);
        }
    }
}

