using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<User> _userService;

        public UserController(IService<User> userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> UserIndex(User user)
        {
            return View(user);
        }

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }
    }
}
