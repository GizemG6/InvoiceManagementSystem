using System.ComponentModel.DataAnnotations;

namespace FaturaYönetimSistemi.Models.Entities
{
    public class NaturalGasBill
    {
        [Key]
        public int NaturalGasBillID { get; set; }
        public string NaturalGasBillSerialNumber { get; set; } 
        public string NaturalGasBillSequenceNo { get; set; } 
        public string NaturalGasBillCompanyName { get; set; }
        public int NaturalGasBillPrice { get; set; }
        public DateTime NaturalGasBillDate { get; set; }
        public string NaturalGasBilllDescription { get; set; }
        public bool NaturalGasBillStatus { get; set; } = false;

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
