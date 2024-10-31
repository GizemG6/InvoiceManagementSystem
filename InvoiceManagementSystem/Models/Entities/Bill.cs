using InvoiceManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementSystem.Models.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public BillType BillType { get; set; }
        public double Amount { get; set; }
        public DateTime BillDate {  get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDelete { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Payment Payment { get; set; }
    }
}
