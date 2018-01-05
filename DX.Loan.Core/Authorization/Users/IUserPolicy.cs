using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace DX.Loan.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
