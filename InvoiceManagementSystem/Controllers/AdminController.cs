using InvoiceManagementSystem.Common;
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

        public AdminController(IService<User> userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        public async Task<IActionResult> AdminIndex()
        {
            var users = await _context.Users.Include(u => u.Apartments).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> ListUser(int id)
        {
            var user = new User();
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

            return RedirectToAction("ListUser");
        }
        public async Task<IActionResult> RemoveUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);
            return RedirectToAction("AdminIndex");
        }
        public async Task<IActionResult> UpdateUser(User User)
        {
            await _userService.UpdateAsync(User);
            return View();
        }
    }
}
