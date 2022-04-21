using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyATMProject.Configuration;

namespace MyATMProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MyATMProjectWebCoreModule))]
    public class MyATMProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyATMProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyATMProjectWebHostModule).GetAssembly());
        }
    }
}
