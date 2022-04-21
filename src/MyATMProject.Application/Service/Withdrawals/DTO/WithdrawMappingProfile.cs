using AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Withdrawals.DTO
{
    public class WithdrawMappingProfile : Profile
    {
        public WithdrawMappingProfile()
        {
            CreateMap<Withdraw, WithdrawDTO>();
            CreateMap<WithdrawDTO, Withdraw>();

        }
    }
}
