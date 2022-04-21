using System.Threading.Tasks;
using MyATMProject.Configuration.Dto;

namespace MyATMProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
