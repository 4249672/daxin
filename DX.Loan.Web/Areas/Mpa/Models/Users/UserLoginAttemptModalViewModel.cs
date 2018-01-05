using System.Collections.Generic;
using DX.Loan.Authorization.Users.Dto;

namespace DX.Loan.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}