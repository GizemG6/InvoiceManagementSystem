namespace InvoiceManagementSystem.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
