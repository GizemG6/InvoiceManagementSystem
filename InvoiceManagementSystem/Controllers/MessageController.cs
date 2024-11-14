using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Controllers
{
    public class MessageController : Controller
    {
        private readonly IService<Message> _messageService;
        private readonly ApplicationDbContext _context;

        public MessageController(IService<Message> messageService, ApplicationDbContext context)
        {
            _messageService = messageService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageService.GetAllAsync();
            return View(messages);
        }
        public async Task<IActionResult> SendMessageToAdmin(int RecipientId, string Title, string Comment)
        {
            var user = await _context.Users.FindAsync(RecipientId);

            var message = new Message
            {
                SenderId = user.Id,
                RecipientId = RecipientId, 
                Title = Title,
                Comment = Comment,
                Status = false,
                SendDate = DateTime.Now,
                IsDelete = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserIndex", "User");
        }

    }
}
