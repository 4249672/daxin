using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Customer
{
    public class SearchCustomerInput: IPagedResultRequest
    {
        //[Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int? minAge { get; set; }

        [Range(1, 100)]
        public int? maxAge { get; set; }

        //芝麻分
        [Range(0, 2000)]
        public int? minScore { get; set; }

        [Range(0, 2000)]
        public int? maxScore { get; set; }
        
        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }


        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
    }
}
