using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repositories
{
    public class HospitalAppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public HospitalAppDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-8QVR89KA\SQLEXPRESS02;uid=sa;pwd=12345;database=PRN211HospitalApp;TrustServerCertificate=True");
        }
    }
}
