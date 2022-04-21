using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Domains
{
    public class Transaction: Entity<Guid>
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }

        // many-to-many
        public List<BankAccount_Transaction> BankAccount_Transactions { get; set; }
    }

    public class Withdraw: Transaction
    {

    }

    public class Deposit: Transaction
    {

    }

    //public class Transfer: Transaction
    //{
    //    public string TransferAccount { get; set; }
    //}
}
