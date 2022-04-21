using AutoMapper;
using MyATMProject.Domains;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.BankAccounts.DTO
{
    public class BankAccountMappingProfile: Profile
    {
        public BankAccountMappingProfile()
        {
            CreateMap<BankAccount, BankAccountDTO>()
                .ForMember(e => e.ClientId, m => m.MapFrom(e => e.Client != null ? e.Client.Id : (Guid?)null));
            CreateMap<BankAccountDTO, BankAccount>()
                .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}
