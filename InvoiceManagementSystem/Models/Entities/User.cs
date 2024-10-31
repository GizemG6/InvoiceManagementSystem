using InvoiceManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementSystem.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; } // admin or resident
        public string Email { get; set; }
        public string Password { get; set; }
        public string TCNo { get; set; }
        public string Phone { get; set; }
        public string CarsPlate { get; set; }
        public bool IsOwner { get; set; } // whether the user is an apartment owner or not
        public int ApartmentId { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<Bill> Bills {  get; set; }
    }
}
