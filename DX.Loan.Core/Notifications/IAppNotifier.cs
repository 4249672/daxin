using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using DX.Loan.Authorization.Users;
using DX.Loan.MultiTenancy;

namespace DX.Loan.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
