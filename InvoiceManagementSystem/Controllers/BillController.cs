using InvoiceManagementSystem.Enums.EnumHelper;
using InvoiceManagementSystem.Enums;
using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Controllers
{
    public class BillController : Controller
    {
        private readonly IService<Bill> _billService;
        private readonly ApplicationDbContext _context;

        public BillController(IService<Bill> billService, ApplicationDbContext context)
        {
            _billService = billService;
            _context = context;
        }

        public async Task<IActionResult> ListBillForCreate(int id)
        {
            var bills = new Bill();
            ViewBag.BillTypes = EnumHelper.GetEnumSelectList<BillType>();
            return View(bills);
        }

        public async Task<IActionResult> CreateBill(Bill bill)
        {
            bill.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == bill.UserId);
            if (ModelState.IsValid)
            {
                await _billService.CreateAsync(bill);
                return RedirectToAction("AdminIndex", "Admin");
            }
            return RedirectToAction("ListBillForCreate");
        }
    }
}
