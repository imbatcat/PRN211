using Core.Accounts;
using Entities;
using Repositories.Interfaces;

namespace Repositories.Repos
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly IRepositoryBase<Account> _repository;

        public AccountRepository()
        {
            _repository = new RepositoryBase<Account>();
        }

        public IEnumerable<DoctorDTO>? GetAllDoctors()
        {
            var accounts = _repository.GetAll();
            List<DoctorDTO> res = [];
            foreach (Account acc in accounts)
            {
                if (acc.Discriminator == "Doctor")
                {
                    res.Add(new DoctorDTO
                    {
                        DateOfBirth = acc.DateOfBirth,
                        Department = acc.Department,
                        DoctorName = acc.FullName,
                        Email = acc.Email,
                        IsMale = acc.IsMale,
                        JoinDate = acc.JoinDate
                    });

                }
            }
            return res;
        }

        public LoginAccountDTO? Login(string username, string password)
        {
            var status = _repository.Any(x => x.UserName == username && x.Password == password);
            if (status)
            {
                Account? acc = _repository.GetByCondition(x => x.UserName == username);
                return new LoginAccountDTO 
                {
                    Discriminator = acc.Discriminator,
                    FullName = acc.FullName,
                    Id = acc.Id,
                };
            }
            return null;
        }
    }
}
