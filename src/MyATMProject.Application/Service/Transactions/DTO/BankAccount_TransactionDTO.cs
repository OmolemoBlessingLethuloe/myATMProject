using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Transactions.DTO
{
    [AutoMapFrom(typeof(BankAccount_Transaction))]
    public class BankAccount_TransactionDTO: EntityDto<Guid>
    {
        public Guid? BankAccountId { get; set; }
        public Guid? TransactionId { get; set; }
    }

    public class TransactionHistoryDTO: EntityDto<Guid>
    {
        public string ClientName { get; set; }
        public List<BankAccountTransactionDTO> BankTransactions { get; set; }
    }

    public class BankAccountTransactionDTO: EntityDto<Guid>
    {
        public string AccountNumber { get; set; }
        public string TransactionType { get; set; }
        public List<decimal> BankTransactions { get; set; }

    }
}
