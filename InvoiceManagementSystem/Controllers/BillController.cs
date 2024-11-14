using InvoiceManagementSystem.Enums.EnumHelper;
using InvoiceManagementSystem.Enums;
using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var bill = await _context.Bills
                         .Include(b => b.User)
                         .FirstOrDefaultAsync(b => b.Id == id);

            ViewBag.BillTypes = Enum.GetValues(typeof(BillType))
                        .Cast<BillType>()
                        .Select(b => new SelectListItem
                        {
                            Text = b.ToString(),
                            Value = ((int)b).ToString()
                        }).ToList();

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
            var _bill = await _context.Bills.AsNoTracking().FirstOrDefaultAsync(b => b.Id == bill.Id);
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _bill.BillType = bill.BillType;
                _bill.Amount = bill.Amount;
                _bill.BillDate = bill.BillDate;
                _bill.Description = bill.Description;
                _bill.IsPaid = bill.IsPaid;
                _bill.UserId = bill.UserId;

                await _billService.UpdateAsync(bill);
                return RedirectToAction("AdminIndex", "Admin");
            }
            return RedirectToAction("ListBillForUpdate");
        }
    }
}
