using System.Collections.Generic;
using DX.Loan.Auditing.Dto;
using DX.Loan.Dto;

namespace DX.Loan.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
