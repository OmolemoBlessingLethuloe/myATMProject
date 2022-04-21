using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyATMProject.Domains;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Clients
{
    public interface IClientAppService: IApplicationService
    {
        Task<ClientDTO> CreateAsync(ClientDTO input);
        Task<ClientDTO> UpdatePin(ClientDTO input);
        Task<ClientDTO> UpdateName(ClientDTO input);
        Task<PagedResultDto<ClientDTO>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<ClientDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        void DeleteAsync(Guid id);

    }
}
