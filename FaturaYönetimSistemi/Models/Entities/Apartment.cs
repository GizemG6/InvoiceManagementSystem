using System.ComponentModel.DataAnnotations;

namespace FaturaYönetimSistemi.Models.Entities
{
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }
        public string ApartmentNo { get; set; }
        public string Floor { get; set;}
        public string ApartmentBlock { get; set;}
        public string HomeType { get; set; }
        public bool Status { get; set; } = false;

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
