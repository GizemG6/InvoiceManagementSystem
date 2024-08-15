using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IRepository<Message> _messageRepository;
        public MessagesController(IRepository<Message> messageRepository) 
        {
           _messageRepository = messageRepository;
        }
        public async Task<IActionResult> Index()
        {
            var messages = await _messageRepository.GetAllAsync();
            return View(messages);
        }
    }
}
