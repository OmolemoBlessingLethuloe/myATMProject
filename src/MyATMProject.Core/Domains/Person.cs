using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Domains
{
    public class Person: Entity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }

    }

    public class Admin: Person
    {
    }

    public class Client: Person
    {
        // navigation properties
        // accounts - many to one
        public List<BankAccount> BankAccounts { get; set; }
    }
}
