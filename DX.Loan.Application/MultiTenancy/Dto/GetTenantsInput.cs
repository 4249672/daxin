using Abp.Runtime.Validation;
using DX.Loan.Dto;

namespace DX.Loan.MultiTenancy.Dto
{
    public class GetTenantsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "TenancyName";
            }

            Sorting = Sorting.Replace("editionDisplayName", "Edition.DisplayName");
        }
    }
}
