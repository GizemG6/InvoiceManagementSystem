using FaturaYönetimSistemi.Models.DB;
using FaturaYönetimSistemi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FaturaYönetimSistemi.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }

        public async Task<User> GetUserWithDetailsAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
