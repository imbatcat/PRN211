using Core.Accounts;
using Entities;

namespace Repositories.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        public AdminDTO? Login(string username, string password);
        public IEnumerable<DoctorDTO>? GetAllDoctors();
    }
}
