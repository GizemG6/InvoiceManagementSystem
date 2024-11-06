using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
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

        public async Task<IActionResult> ListApartment()
        {
            var apartments = new Apartment();
            return View(apartments);
        }
        public async Task<IActionResult> CreateApartment(Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                await _apartmentService.CreateAsync(apartment);
                return RedirectToAction("AdminIndex");
            }
            return RedirectToAction("ListApartment");
        }
    }
}
