using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyATMProject.Configuration.Dto;

namespace MyATMProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyATMProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
