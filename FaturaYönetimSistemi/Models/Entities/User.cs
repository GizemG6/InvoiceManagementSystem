namespace FaturaYönetimSistemi.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TCNo { get; set; }
        public string Phone { get; set; }
        public string CarsPlate { get; set; }
        public bool ApartmentOwner { get; set; }
        public int? ApartmentId { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<Apartment> Apartment { get; set; }
        public ICollection<Dues> Dues { get; set; }
        public ICollection<ElectricityBill> ElectricityBill { get; set; }
        public ICollection<WaterBill> WaterBill { get; set; }
        public ICollection<NaturalGasBill> NaturalGasBill { get; set; }
    }
}
