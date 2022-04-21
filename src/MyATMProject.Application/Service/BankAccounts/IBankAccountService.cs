using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.BankAccounts
{
    public interface IBankAccountService: IApplicationService
    {
        Task<BankAccountDTO> CreateAsync(BankAccountDTO input);
        Task<BankAccountDTO> UpdateBalance(BankAccountDTO input);
        Task<PagedResultDto<BankAccountDTO>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<BankAccountDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        void DeleteAsync(Guid id);
    }
}
