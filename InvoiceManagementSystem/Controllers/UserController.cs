using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
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

        public UserController(IService<User> userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
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
