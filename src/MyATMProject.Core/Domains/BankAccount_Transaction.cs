using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Domains
{
    public class BankAccount_Transaction: Entity<Guid>
    {
        public BankAccount BankAccount { get; set; }
        public Transaction Transaction { get; set; }

    }
}
