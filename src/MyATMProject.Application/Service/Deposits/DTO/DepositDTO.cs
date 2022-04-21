using Abp.AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Deposits.DTO
{
    [AutoMapFrom(typeof(Deposit))]
    public class DepositDTO
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
