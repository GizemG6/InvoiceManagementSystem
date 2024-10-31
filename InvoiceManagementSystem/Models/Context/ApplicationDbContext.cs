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
        public DbSet<Payment> Payment { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete değil

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Bill)
                .WithOne(b => b.Payment) // Bir fatura yalnızca bir ödeme alır
                .HasForeignKey<Payment>(p => p.BillId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete değil

            base.OnModelCreating(modelBuilder);
        }


    }
}
