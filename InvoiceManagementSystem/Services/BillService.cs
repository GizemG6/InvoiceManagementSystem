using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Services
{
    public class BillService : IService<Bill>
    {
        private readonly ApplicationDbContext _context;

        public BillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bill>> GetAllAsync()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill?> GetByIdAsync(int id)
        {
            return await _context.Bills
                         .Include(b => b.User) 
                         .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task RemoveAsync(Bill bill)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
        }
    }
}
