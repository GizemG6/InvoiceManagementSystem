using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Services
{
    public class UserService : IService<User>
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task RemoveAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
