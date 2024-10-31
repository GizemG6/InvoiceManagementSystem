using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Services
{
    public class ApartmentService : IService<Apartment>
    {
        private readonly ApplicationDbContext _context;

        public ApartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Apartment>> GetAllAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment?> GetByIdAsync(int id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public async Task RemoveAsync(Apartment apartment)
        {
            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
            await _context.SaveChangesAsync();
        }
    }
}
