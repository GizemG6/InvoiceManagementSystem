using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class DuesController : Controller
    {
        private readonly IRepository<Dues> _duesRepository;
        public DuesController(IRepository<Dues> duesRepository)
        {
            _duesRepository = duesRepository;
        }
        public async Task<IActionResult> Index()
        {
            var dues = await _duesRepository.GetAllAsync();
            return View(dues);
        }
    }
}
