using System.ComponentModel.DataAnnotations;

namespace FaturaYönetimSistemi.Models.Entities
{
    public class WaterBill
    {
        [Key]
        public int WaterBillID { get; set; }
        public string WaterBillSerialNumber { get; set; } 
        public string WaterBillSequenceNo { get; set; } 
        public string WaterBillCompanyName { get; set; }
        public int WaterBillPrice { get; set; }
        public DateTime WaterBillDate { get; set; }
        public string WaterBillDescription { get; set; }
        public bool WaterBillStatus { get; set; } = false;

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
