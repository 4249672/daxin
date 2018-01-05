using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace DX.Loan.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}