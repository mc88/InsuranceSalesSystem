using System;
using System.Collections.Generic;

namespace PricingService.Bo.Domain
{
    public class Tariff : BaseEntity
    {
        public string Code { get; set; }

        public virtual IList<TariffVersion> TariffVersions { get; set; }

        public PolicyPrice CalculatePolicyPrice(PolicyPrice policyPrice, int age, DateTime policyStartDate)
        {
            throw new NotImplementedException();
        }
    }
}
