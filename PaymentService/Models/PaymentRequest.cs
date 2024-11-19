namespace PaymentService.Models
{
    public class PaymentRequest
    {
        public string BillId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public CardDetails CardDetails { get; set; }
    }
}
