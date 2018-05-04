using System.Reflection;
using Abp.AutoMapper;
using Abp.Localization;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using DX.Loan.Authorization;
using DX.Loan.DtoMapper;

namespace DX.Loan
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(typeof(LoanCoreModule))]
    public class LoanApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper mappings
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                CustomDtoMapper.CreateMappings(mapper);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //注册IDtoMapping  参考 CustomerInfoDtoMapping 自定义Mapper
            IocManager.IocContainer.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .IncludeNonPublicTypes()
                    .BasedOn<IDtoMapping>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
            );

            //解析依赖，并进行映射规则创建
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                var mappers = IocManager.IocContainer.ResolveAll<IDtoMapping>();
                foreach (var dtomap in mappers)
                    dtomap.CreateMapping(mapper);
            });
            
        }
    }
}
