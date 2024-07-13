using Core.Accounts;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        public LoginAccountDTO? Login(string username, string password);
        public IEnumerable<DoctorDTO>? GetAllDoctors();
        public IEnumerable<Account> GetDoctorWithDepartment(string department);

        public IEnumerable<Account> GetDocByCondition(string docName);
    }
}
