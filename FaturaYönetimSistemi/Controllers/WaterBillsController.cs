using FaturaYönetimSistemi.Models.Entities;
using FaturaYönetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class WaterBillsController : Controller
    {
        private readonly IRepository<WaterBill> _waterBillRepository;
        public WaterBillsController(IRepository<WaterBill> waterBillRepository) 
        {
           _waterBillRepository = waterBillRepository;
        }
        public async Task<IActionResult> Index()
        {
            var waterBills = await _waterBillRepository.GetAllAsync();
            return View(waterBills);
        }
    }
}
