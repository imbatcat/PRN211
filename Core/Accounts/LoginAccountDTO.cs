using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Accounts
{
    public class LoginAccountDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Discriminator { get; set; }
    }
}
