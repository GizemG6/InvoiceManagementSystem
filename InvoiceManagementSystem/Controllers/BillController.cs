using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Controllers
{
    public class BillController : Controller
    {
        private readonly IService<Bill> _billService;

        public BillController(IService<Bill> billService)
        {
            _billService = billService;
        }

        public async Task<IActionResult> Index()
        {
            var bills = await _billService.GetAllAsync();
            return View(bills);
        }
    }
}
