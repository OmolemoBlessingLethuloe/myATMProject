using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.DTO
{
    [AutoMapFrom(typeof(BankAccount))]
    public class BankAccountDTO: EntityDto<Guid>
    {
        public string AccountNumber { get; set; }
        public decimal AvailableBalance { get; set; }
        public Guid? ClientId { get; set; }
    }
}
