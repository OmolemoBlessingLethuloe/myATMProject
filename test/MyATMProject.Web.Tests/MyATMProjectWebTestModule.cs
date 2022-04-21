using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyATMProject.EntityFrameworkCore;
using MyATMProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyATMProject.Web.Tests
{
    [DependsOn(
        typeof(MyATMProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyATMProjectWebTestModule : AbpModule
    {
        public MyATMProjectWebTestModule(MyATMProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyATMProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyATMProjectWebMvcModule).Assembly);
        }
    }
}