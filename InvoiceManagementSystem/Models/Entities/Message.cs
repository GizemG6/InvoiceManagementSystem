namespace InvoiceManagementSystem.Models.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; } // the user who sent the message
        public int RecipientId { get; set; } // recipient of the message (admin or user)
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
