using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly IRepository<Apartment> _apartmentRepository;
        public ApartmentsController(IRepository<Apartment> apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var apartments = await _apartmentRepository.GetAllAsync();
            return View(apartments);
        }
    }
}
