using System;
using System.Collections.Generic;

namespace PricingService.Bo.Domain
{
    public class TariffVersion : BaseEntity
    {
        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }
        
        public virtual IList<CoverPrice> CoverPrices { get; set; }
    }
}
