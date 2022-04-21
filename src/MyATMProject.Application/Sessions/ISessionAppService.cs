using System.Threading.Tasks;
using Abp.Application.Services;
using MyATMProject.Sessions.Dto;

namespace MyATMProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
