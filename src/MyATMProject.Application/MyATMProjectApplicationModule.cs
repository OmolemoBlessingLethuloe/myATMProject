using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyATMProject.Authorization;

namespace MyATMProject
{
    [DependsOn(
        typeof(MyATMProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyATMProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyATMProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyATMProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
