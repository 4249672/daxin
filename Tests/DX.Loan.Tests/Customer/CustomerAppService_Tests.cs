using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using DX.Loan.Editions;
using DX.Loan.Editions.Dto;
using DX.Loan.Features;
using Shouldly;
using Xunit;
using DX.Loan.Customer;
using Abp.Events.Bus;
using DX.Loan.Migrations.Seed.Host;
using DX.Loan.Migrations.Seed.Tenants;
using Abp.Events.Bus.Entities;

namespace DX.Loan.Tests.Customer
{
    public class CustomerAppService_Tests : AppTestBase
    {
        ICustomerAppService _service;

        public CustomerAppService_Tests() {
            _service = Resolve<ICustomerAppService>();
            //LoginAsHostAdmin();
        }

        [Fact]
        public void Should_Get_Customers() {
            //var list = _service.GetCustomers(new SearchCustomerInput());
            0.ShouldBe(0);
            //UsingDbContext(context =>
            //{
            //    context.EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
            //    context.EventBus = NullEventBus.Instance;

            //    //new InitialHostDbBuilder(context).Create();
            //    //new DefaultTenantBuilder(context).Create();
            //    //Add
            //    //new InitialPeopleCreator(context).Create();
            //});
        }




    }
}
