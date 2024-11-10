using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IService<Apartment> _apartmentService;
        private readonly ApplicationDbContext _context;

        public ApartmentController(IService<Apartment> apartmentService, ApplicationDbContext context)
        {
            _apartmentService = apartmentService;
            _context = context;
        }

        public async Task<IActionResult> ListApartmentForCreate(int id)
        {
            var apartments = new Apartment();
            return View(apartments);
        }

        public async Task<IActionResult> ListApartmentForUpdate(int id)
        {
            var apartment = await _apartmentService.GetByIdAsync(id);
            return View(apartment);
        }

        public async Task<IActionResult> CreateApartment(Apartment apartment)
        {
            apartment.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == apartment.UserId);
            if (ModelState.IsValid)
            {
                await _apartmentService.CreateAsync(apartment);
                return RedirectToAction("AdminIndex", "Admin");
            }
            return RedirectToAction("ListApartmentForCreate");
        }

        public async Task<IActionResult> RemoveApartment(int id)
        {
            var apartment = await _apartmentService.GetByIdAsync(id);
            await _apartmentService.RemoveAsync(apartment);
            return RedirectToAction("AdminIndex", "Admin");
        }
        
        public async Task<IActionResult> UpdateApartment(Apartment apartment)
        {
            var _apartment = await _apartmentService.GetByIdAsync(apartment.Id);

            if (ModelState.IsValid)
            {
                _apartment.ApartmentNo = apartment.ApartmentNo;
                _apartment.Floor = apartment.Floor;
                _apartment.Block = apartment.Block;
                _apartment.Type = apartment.Type;
                _apartment.Status = apartment.Status;
                _apartment.UserId = apartment.UserId;
                await _apartmentService.UpdateAsync(_apartment);
                return RedirectToAction("AdminIndex", "Admin");
            }
            return RedirectToAction("ListApartmentForUpdate");
        }
    }
}
