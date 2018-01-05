using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DX.Loan.Common.Dto;

namespace DX.Loan.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetEditionsForCombobox();

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        string GetDefaultEditionName();
    }
}