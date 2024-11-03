using InvoiceManagementSystem.Common;
using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IService<User> _userService;

        public HomeController(ApplicationDbContext context, IService<User> userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> UserLogin(User user)
        {
            user.Password = PasswordGenerator.GeneratePassword();
            user.Role = Enums.Role.Resident;

            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                await _userService.CreateAsync(user);
                return RedirectToAction("Index", "User");
            }

            return View("Index");
        }

        public async Task<IActionResult> AdminLogin(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                ViewBag.ShowError = true;
            }
            return View("Index", loginUser);
        }
    }
}
