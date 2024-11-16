using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task<IActionResult> SendMessageToAdmin(int SenderId, int RecipientId, string Title, string Comment)
        {

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

            return RedirectToAction("UserIndex", "User");
        }

    }
}
