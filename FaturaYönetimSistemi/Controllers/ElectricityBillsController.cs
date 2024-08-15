using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class ElectricityBillsController : Controller
    {
        private readonly IRepository<ElectricityBill> _electricityBillRepository;
        public ElectricityBillsController(IRepository<ElectricityBill> electricityBillRepository) 
        {
           _electricityBillRepository = electricityBillRepository;
        }
        public async Task<IActionResult> Index()
        {
            var electricityBills = await _electricityBillRepository.GetAllAsync();
            return View(electricityBills);
        }
    }
}
