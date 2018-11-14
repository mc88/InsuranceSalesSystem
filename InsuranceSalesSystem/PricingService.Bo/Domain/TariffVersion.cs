using System;
using System.Collections.Generic;
using System.Linq;

namespace PricingService.Bo.Domain
{
    public class TariffVersion : BaseEntity
    {
        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }

        public int TariffId { get; set; }

        public virtual IList<CoverPrice> CoverPrices { get; set; }

        public CoverPrice GetCoverPrice(string coverCode, int age)
        {
            return CoverPrices.FirstOrDefault(x => x.Code == coverCode && x.AgeFrom <= age && x.AgeTo >= age);
        }
    }
}
