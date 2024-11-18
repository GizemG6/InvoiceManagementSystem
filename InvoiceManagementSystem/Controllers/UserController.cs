using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<User> _userService;
        private readonly ApplicationDbContext _context;
        private readonly MessageService _messageService;

        public UserController(IService<User> userService, ApplicationDbContext context, MessageService messageService)
        {
            _userService = userService;
            _context = context;
            _messageService = messageService;
        }

        public async Task<IActionResult> UserIndex(LoginUser loginUser)
        {
            User user = null;

            if (TempData["UserId"] != null)
            {
                int userId = Convert.ToInt32(TempData["UserId"]);
                user = await _context.Users
                    .Include(u => u.Bills)
                    .FirstOrDefaultAsync(u => u.Id == userId);
            }

            else if (loginUser != null && !string.IsNullOrEmpty(loginUser.Email))
            {
                user = await _context.Users
                    .Include(u => u.Bills)
                    .FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            }

            var messages = await _messageService.GetAllAsync();

            ViewBag.Messages = messages
                .Where(m => !m.IsDelete && m.RecipientId == user.Id) 
                .Select(m => new
                {
                    Title = m.Title,
                    Comment = m.Comment,
                    SenderName = _context.Users
                                 .Where(u => u.Id == m.UserId)
                                 .Select(u => u.FirstName + " " + u.LastName)
                                 .FirstOrDefault() ?? "Bilinmiyor",
                    SendDate = m.SendDate.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

            ViewBag.Users = await _context.Users
                            .Where(u => !u.IsDelete)
                            .Select(u => new SelectListItem
                            {
                               Text = u.FirstName + " " + u.LastName,
                               Value = u.Id.ToString()
                            }).ToListAsync();

            return View(user);
        }

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }


    }
}
