using System.ComponentModel.DataAnnotations;

namespace FaturaYönetimSistemi.Models.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Date { get; set; }
    }
}
