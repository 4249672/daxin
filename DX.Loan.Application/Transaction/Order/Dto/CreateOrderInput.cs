using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Order.Dto
{
    public class CreateOrderInput
    {
        //public string OrderNo { get; set; }

        //public string Status { get; set; }

        //public decimal? OrderAmount { get; set; }

        //public long UserId { get; set; }

        //------------------------------------------

        public long CustomerId { get; set; }




    }
}
