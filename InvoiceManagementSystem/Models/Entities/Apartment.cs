using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementSystem.Models.Entities
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public string ApartmentNo { get; set; }
        public string Floor { get; set; }
        public string Block { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
