using InvoiceManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
