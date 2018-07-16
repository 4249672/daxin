using Abp.Runtime.Validation;
using DX.Loan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan
{
    public class SearchNoticeInput : PagedAndSortedInputDto, IShouldNormalize, ICustomValidate
    {
        public string Title { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        
        public void AddValidationErrors(CustomValidationContext context)
        {
            
        }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
                this.Sorting = "PublicDate DESC , CreationTime DESC";

            if (!StartDate.HasValue)
                StartDate = DateTime.Now.AddDays(-60);
            if (!EndDate.HasValue)
                EndDate = DateTime.Now;
        }
    }
}
