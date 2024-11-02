using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InvoiceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<User> _userService;

        public UserController(IService<User> userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.CreateAsync(user);
            return View(user);
        }
        public async Task<IActionResult> RemoveUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);
            return View();
        }
        public async Task<IActionResult> UpdateUser(User User)
        {
            await _userService.UpdateAsync(User);
            return View();
        }
    }
}
