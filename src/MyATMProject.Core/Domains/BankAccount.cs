using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Domains
{
    public class BankAccount: Entity<Guid>
    {
        public string AccountNumber { get; set; }
        public decimal AvailableBalance { get; set; }

        //  one-to-many
        public Client Client { get; set; }
        // many-to-many
        public List<BankAccount_Transaction> BankAccount_Transactions { get; set; }


    }
}
