using System.Collections.Generic;
using DX.Loan.Caching.Dto;

namespace DX.Loan.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}