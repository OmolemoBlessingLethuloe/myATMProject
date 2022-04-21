using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Withdrawals.DTO
{
    [AutoMapFrom(typeof(Withdraw))]
    public class WithdrawDTO: EntityDto<Guid>
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
