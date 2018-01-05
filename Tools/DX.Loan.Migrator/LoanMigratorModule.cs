using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using DX.Loan.EntityFramework;

namespace DX.Loan.Migrator
{
    [DependsOn(typeof(LoanDataModule))]
    public class LoanMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<LoanDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}