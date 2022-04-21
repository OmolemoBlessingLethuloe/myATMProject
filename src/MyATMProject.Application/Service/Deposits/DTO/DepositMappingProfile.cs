using AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Deposits.DTO
{
    public class DepositMappingProfile: Profile
    {
        public DepositMappingProfile()
        {
            CreateMap<Deposit, DepositDTO>();
            CreateMap<DepositDTO, Deposit>();
        }
    }
}
