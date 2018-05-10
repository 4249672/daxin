using Abp.Application.Services.Dto;
using DX.Loan.Authorization.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DX.Loan.Web.Areas.Mpa.Models.Trade
{
    public class UsersListViewModel
    {
        public PagedResultDto<UserListDto> Users { get; set; }
    }
}