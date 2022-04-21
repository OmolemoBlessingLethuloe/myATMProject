using AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Transactions.DTO
{
    public class BankAccount_TransactionMappingProfile: Profile
    {
        public BankAccount_TransactionMappingProfile()
        {
            CreateMap<BankAccount_Transaction, BankAccount_TransactionDTO>()
                .ForMember(e => e.BankAccountId, m => m.MapFrom(e => e.BankAccount != null ? e.BankAccount.Id : (Guid?)null))
                .ForMember(e => e.TransactionId, m => m.MapFrom(e => e.Transaction != null ? e.Transaction.Id : (Guid?)null));

            CreateMap<BankAccount_TransactionDTO, BankAccount_Transaction>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
