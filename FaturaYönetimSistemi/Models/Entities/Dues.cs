using System.ComponentModel.DataAnnotations;

namespace FaturaYönetimSistemi.Models.Entities
{
    public class Dues
    {
        [Key]
        public int DuesId { get; set; }
        public int Price { get; set;}
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = false;

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
