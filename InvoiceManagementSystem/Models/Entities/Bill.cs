using InvoiceManagementSystem.Enums;

namespace InvoiceManagementSystem.Models.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public BillType BillType { get; set; }
        public double Amount { get; set; }
        public DateTime BillDate {  get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDelete { get; set; }
    }
}
