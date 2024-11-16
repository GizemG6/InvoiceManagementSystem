using InvoiceManagementSystem.Models.Context;
using InvoiceManagementSystem.Models.Entities;
using InvoiceManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Services
{
    public class MessageService : IService<Message>
    {
        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            return message ?? throw new InvalidOperationException("Message not found");
        }

        public async Task RemoveAsync(Message message)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> ListMessage(int SenderId)
        {
            var messages = await _context.Messages
                           .Where(m => m.RecipientId == SenderId && !m.IsDelete)
                           .Include(m => m.User)
                           .ToListAsync();
            return messages;
        }
    }
}
