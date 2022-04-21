using Abp.Application.Services;
using MyATMProject.MultiTenancy.Dto;

namespace MyATMProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

