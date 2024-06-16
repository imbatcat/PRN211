using Core;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IRepositoryBase<Account> _repository;

        public AccountRepository()
        {
            _repository = new RepositoryBase<Account>();
        }

        public AdminDTO? Login(string username, string password)
        {
            var status = _repository.Any(x => x.UserName == username && x.Password == password);
            if (status)
            {
                var acc = _repository.GetByCondition(x => x.UserName == username);
                return new AdminDTO { Discrimator = acc.Discriminator, FullName = acc.FullName };
            }
            return null;
        }
    }
}
