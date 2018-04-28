using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Trade.Dto
{
    public class RechargeInput
    {
        [Required]
        public long userId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
