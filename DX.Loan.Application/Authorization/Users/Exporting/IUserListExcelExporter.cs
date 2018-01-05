using System.Collections.Generic;
using DX.Loan.Authorization.Users.Dto;
using DX.Loan.Dto;

namespace DX.Loan.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}