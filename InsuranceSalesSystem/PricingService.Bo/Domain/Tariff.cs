using System;
using System.Collections.Generic;

namespace PricingService.Bo.Domain
{
    public class Tariff
    {
        public string Code { get; set; }

        public IList<TariffVersion> TariffVersions { get; set; }

        public PolicyPrice CalculatePolicyPrice(PolicyPrice policyPrice)
        {
            throw new NotImplementedException();
        }
    }
}
