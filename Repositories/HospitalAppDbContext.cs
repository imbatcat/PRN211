using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class HospitalAppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<AppointmentRequest> AppointmentRequests { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public object Account { get; internal set; }

        public HospitalAppDbContext() : base()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(GetConnectionString());
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

            return strConn;
        }
    }
}