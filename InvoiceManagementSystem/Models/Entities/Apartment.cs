namespace InvoiceManagementSystem.Models.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string ApartmentNo { get; set; }
        public string Floor { get; set; }
        public string Block { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
    }
}
