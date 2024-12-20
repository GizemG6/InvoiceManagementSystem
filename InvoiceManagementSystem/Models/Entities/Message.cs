﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementSystem.Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int RecipientId { get; set; } // recipient of the message (admin or user)
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsDelete { get; set; }

        public int UserId { get; set; } // the user who sent the message
        public User? User { get; set; }
    }
}
