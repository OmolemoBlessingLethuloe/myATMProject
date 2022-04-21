using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Transactions
{
    public interface ITransactionAppService: IApplicationService
    {
        Task<TransactionDTO> Deposit(TransactionDTO input);
        Task<TransactionDTO> Withdraw(TransactionDTO input);
        Task<TransactionDTO> Transfer(TransactionDTO input);
        Task<PagedResultDto<TransactionDTO>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<TransactionDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        void DeleteAsync(Guid id);
    }
}
