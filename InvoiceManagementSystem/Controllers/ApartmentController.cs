using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IService<Apartment> _apartmentService;

        public ApartmentController(IService<Apartment> apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public async Task<IActionResult> Index()
        {
            var apartments = await _apartmentService.GetAllAsync();
            return View(apartments);
        }
    }
}
