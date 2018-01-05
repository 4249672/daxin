using System.Threading.Tasks;
using DX.Loan.Sessions.Dto;

namespace DX.Loan.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
