using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyATMProject.Service.Deposits.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Deposits
{
    public interface IDepositAppService: IApplicationService
    {
        Task<DepositDTO> CreateAsync(DepositDTO input);
        Task<PagedResultDto<DepositDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
    }
}
