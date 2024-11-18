using InvoiceManagementSystem.Common;
using InvoiceManagementSystem.Enums;
using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IService<User> _userService;
        private readonly ApplicationDbContext _context;
        private readonly MessageService _messageService;

        public AdminController(IService<User> userService, ApplicationDbContext context, MessageService messageService)
        {
            _userService = userService;
            _context = context;
            _messageService = messageService;
        }
        public async Task<IActionResult> AdminIndex()
        {
            var users = await _context.Users
                        .Include(u => u.Apartments) 
                        .Include(u => u.Bills)
                        .ToListAsync();

            var adminUser = users.FirstOrDefault(u => u.Role == Role.Admin);

            if (users != null)
            {
                ViewBag.RecipientId = adminUser.Id;
                var messages = await _messageService.GetAllAsync();

                // Pass messages to the view using ViewBag
                var adminMessages = messages
            .Where(m => !m.IsDelete && m.RecipientId == adminUser.Id) 
            .Select(m => new
            {
                Title = m.Title,
                Comment = m.Comment,
                SenderName = _context.Users
                    .Where(u => u.Id == m.UserId)
                    .Select(u => u.FirstName + " " + u.LastName)
                    .FirstOrDefault() ?? "Bilinmiyor",
                SendDate = m.SendDate
            })
            .ToList();

                ViewBag.Messages = adminMessages;
            }
            return View(users);
        }

        public async Task<IActionResult> ListUserForCreate(int id)
        {
            var user = new User();
            return View(user);
        }
        public async Task<IActionResult> ListUserForUpdate(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }

        public async Task<IActionResult> CreateUser(User user)
        {
            user.Password = PasswordGenerator.GeneratePassword();
            ModelState.Remove(nameof(user.Password));
            if (ModelState.IsValid)
            {
                await _userService.CreateAsync(user);
                return RedirectToAction("AdminIndex");
            }

            return RedirectToAction("ListUserForCreate");
        }
        public async Task<IActionResult> RemoveUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);
            return RedirectToAction("AdminIndex");
        }
        public async Task<IActionResult> UpdateUser(User user)
        {
            var _user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == user.Id);
            user.Password = _user.Password;
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(user);
                return RedirectToAction("AdminIndex");
            }
            return RedirectToAction("ListUserForUpdate");
        }
    }
}
