using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IRepository<Admin> _adminRepository;
        public AdminsController(IRepository<Admin> adminRepository) 
        { 
            _adminRepository = adminRepository;
        }
        public async Task<IActionResult> Index()
        {
            var admins = await _adminRepository.GetAllAsync();
            return View(admins);
        }
    }
}
