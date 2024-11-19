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

        public async Task<IActionResult> UserLogin(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
                if (user != null)
                {
                    if (user.Role == Enums.Role.Admin)
                    {
                        return RedirectToAction("AdminIndex", "Admin");
                    }
                    else if (user.Role == Enums.Role.Kullanici)
                    {
                        return RedirectToAction("UserIndex", "User", loginUser);
                    }
                }
                ModelState.AddModelError("Password", "Email veya şifre yanlış.");
                ViewBag.ShowError = true;
            }
            return View("Index", loginUser);
        }

    }
}
