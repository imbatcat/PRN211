using Core.Accounts;
using Entities;

namespace Repositories.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        public LoginAccountDTO? Login(string username, string password);
        public IEnumerable<DoctorDTO>? GetAllDoctors();
        public IEnumerable<Account> GetDoctorWithDepartment(string department);
    }
}
