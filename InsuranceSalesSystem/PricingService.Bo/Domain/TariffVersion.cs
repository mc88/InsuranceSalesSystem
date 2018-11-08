using System;
using System.Collections.Generic;

namespace PricingService.Bo.Domain
{
    public class TariffVersion
    {
        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }
        
        public IList<CoverPrice> CoverPrices { get; set; }
    }
}
