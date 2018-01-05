using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using DX.Loan.Authorization.Users;

namespace DX.Loan.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}