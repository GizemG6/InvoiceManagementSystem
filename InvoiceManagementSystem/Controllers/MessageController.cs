using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Controllers
{
    public class MessageController : Controller
    {
        private readonly IService<Message> _messageService;

        public MessageController(IService<Message> messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageService.GetAllAsync();
            return View(messages);
        }
    }
}
