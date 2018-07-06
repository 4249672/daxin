using Abp.Runtime.Validation;
using DX.Loan.Dto;

namespace DX.Loan.Authorization.Users.Dto
{
    public class GetUsersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public string Permission { get; set; }

        public int? Role { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                //Sorting = "Name,Surname";
                Sorting = "CreationTime";
            }
        }
    }
}