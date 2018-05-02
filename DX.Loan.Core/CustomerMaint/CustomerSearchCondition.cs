using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.CustomerMaint
{
    public class CustomerSearchCondition
    {

        public long? Id { get; set; }
        public string Name { get; set; }

        public string Area { get; set; }

        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }


        public string IdCard { get; set; }

        public int? SesameScoreFrom { get; set; }
        public int? SesameScoreTo { get; set; }
        
        public string Tel { get; set; }
        public string WeChat { get; set; }
        public string QQ { get; set; }

        public string AppEquipment { get; set; }
        public string Source { get; set; }

        public int? IsComplete { get; set; }
        public int? TransTimes { get; set; }

        public DateTime? CreationTimeFrom { get; set; }
        public DateTime? CreationTimeTo { get; set; }
    }
}
