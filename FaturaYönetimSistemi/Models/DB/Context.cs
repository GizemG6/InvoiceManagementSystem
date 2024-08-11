using FaturaYönetimSistemi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FaturaYönetimSistemi.Models.DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<ElectricityBill> ElectricityBills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<NaturalGasBill> NaturalGasBills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WaterBill> WaterBills { get; set; }
    }
}
