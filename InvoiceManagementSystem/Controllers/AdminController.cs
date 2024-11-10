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
