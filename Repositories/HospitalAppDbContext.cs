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
            base.Database.SetConnectionString(
                "Server=MEOMATLON\\SQLEXPRESS;uid=sa;pwd=MukuroHoshimiya;" +
                "database=PRN211HospitalApp;TrustServerCertificate=True"
            );
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
