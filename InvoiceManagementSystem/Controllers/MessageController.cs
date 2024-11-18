using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace InvoiceManagementSystem.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;
        private readonly ApplicationDbContext _context;

        public MessageController(MessageService messageService, ApplicationDbContext context)
        {
            _messageService = messageService;
            _context = context;
        }
        public async Task<IActionResult> SendMessage(int SenderId, int RecipientId, string Title, string Comment)
        {
            var sender = await _context.Users.FindAsync(SenderId);

            var newMessage = new Message
            {
                UserId = SenderId,
                RecipientId = RecipientId, 
                Title = Title,
                Comment = Comment,
                Status = false,
                SendDate = DateTime.Now,
                IsDelete = false
            };

            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            TempData["UserId"] = SenderId;

            if (sender.Role.ToString() == "Admin")
            {
                return RedirectToAction("AdminIndex", "Admin");
            }
            else
            {
                return RedirectToAction("UserIndex", "User");
            }
        }

    }
}
