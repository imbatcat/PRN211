using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Repos
{
    public class MedicalRecordRepository : RepositoryBase<MedicalRecord>, IMedicalRecordRepository
    {
        private readonly HospitalAppDbContext _context;
        public readonly IRepositoryBase<MedicalRecord> Repository;
        public MedicalRecordRepository()
        {
            Repository = new RepositoryBase<MedicalRecord>();
            _context = new HospitalAppDbContext();
        }

        public IEnumerable<MedicalRecord> GetAllMedicalRecordsByDocId(Guid doctorId)
        {
            return _context.MedicalRecords.Include("appointment").Where(m => m.appointment.AccountId.Equals(doctorId)).ToList();
        }

        public IEnumerable<MedicalRecord> GetMedicalRecordsByCustomerName(string customerName)
        {
            return _context.MedicalRecords.Where(a => a.CustomerName.Equals(customerName));
        }
    }
}
