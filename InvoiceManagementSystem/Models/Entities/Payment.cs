using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementSystem.Models.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}
