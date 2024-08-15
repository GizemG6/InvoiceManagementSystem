using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<User> _userRepository;
        public UsersController(IRepository<User> userRepository) 
        {
           _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllAsync();
            return View(users);
        }
    }
}
