using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyATMProject.Service.Withdrawals.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Withdrawals
{
    public interface IWithdrawAppService: IApplicationService
    {
        Task<WithdrawDTO> CreateAsync(WithdrawDTO input);
        Task<PagedResultDto<WithdrawDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
    }
}
