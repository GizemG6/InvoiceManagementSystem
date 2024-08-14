using FaturaYönetimSistemi.Models.Entities;

namespace FaturaYönetimSistemi.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithDetailsAsync(int id);
    }
}
