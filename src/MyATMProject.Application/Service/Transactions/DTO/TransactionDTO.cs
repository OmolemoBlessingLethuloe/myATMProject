using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyATMProject.Service.DTO
{
    [AutoMapFrom(typeof(Transaction))]
    public class TransactionDTO: EntityDto<Guid>
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingBalance { get; set; }
    }
}
