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
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Giriş yapmadan mesaj gönderemezsiniz.";
                return RedirectToAction("UserIndex", "User");
            }

            var message = new Message
            {
                SenderId = userId.Value,
                RecipientId = RecipientId, 
                Title = Title,
                Comment = Comment,
                Status = false,
                SendDate = DateTime.Now,
                IsDelete = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Mesaj başarıyla seçilen admin'e gönderildi.";
            return RedirectToAction("UserIndex", "User");
        }

    }
}
