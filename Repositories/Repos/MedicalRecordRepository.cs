using Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class MedicalRecordRepository: RepositoryBase<MedicalRecord>, IMedicalRecordRepository
    {
        private readonly HospitalAppDbContext _context;
        public readonly IRepositoryBase<MedicalRecord> Repository;
        public MedicalRecordRepository()
        {
            Repository = new RepositoryBase<MedicalRecord>();
            _context = new HospitalAppDbContext();
        }
    }
}
