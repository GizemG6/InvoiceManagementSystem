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

        public async Task<IActionResult> ListBillForUpdate(int id)
        {
            var bill = await _billService.GetByIdAsync(id);
            return View(bill);
        }

        public async Task<IActionResult> CreateBill(Bill bill)
        {
            bill.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == bill.UserId);
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                await _billService.CreateAsync(bill);
                return RedirectToAction("AdminIndex", "Admin");
            }
            return RedirectToAction("ListBillForCreate");
        }

        public async Task<IActionResult> RemoveBill(int id)
        {
            var bill = await _billService.GetByIdAsync(id);
            await _billService.RemoveAsync(bill);
            return RedirectToAction("AdminIndex", "Admin");
        }

        public async Task<IActionResult> UpdateBill(Bill bill)
        {
            var _bill = await _billService.GetByIdAsync(bill.Id);
            if (ModelState.IsValid)
            {
                _bill.BillType = bill.BillType;
                _bill.Amount = bill.Amount;
                _bill.BillDate = bill.BillDate;
                _bill.Description = bill.Description;
                _bill.IsPaid = bill.IsPaid;
                _bill.UserId = bill.UserId;
                await _billService.UpdateAsync(_bill);
                return RedirectToAction("AdminIndex", "Admin");
            }
            return RedirectToAction("ListBillForUpdate");
        }
    }
}
