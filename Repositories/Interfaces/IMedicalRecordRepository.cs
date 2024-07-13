using Entities;

namespace Repositories.Interfaces
{
    public interface IMedicalRecordRepository : IRepositoryBase<MedicalRecord>
    {
        public IEnumerable<MedicalRecord> GetAllMedicalRecordsByDocId(Guid doctorId);
        public IEnumerable<MedicalRecord> GetMedicalRecordsByCustomerName(string customerName);
    }
}
