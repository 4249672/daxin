using Abp.Application.Services;
using DX.Loan.Dto;
using DX.Loan.Logging.Dto;

namespace DX.Loan.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
