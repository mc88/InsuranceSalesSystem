using PolicyService.Api.Enums;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PolicyService.Bo.Domain
{
    public class PolicyVersion : BaseEntity
    {
        public PolicyVersion() { }

        public PolicyVersion(Offer offer)
        {
            PolicyNumber = offer.OfferNumber;
            VersionNumber = GetVersionNumber(1);
            PolicyFrom = offer.PolicyFrom;
            PolicyTo = offer.PolicyTo;
            VersionFrom = offer.PolicyFrom;
            VersionTo = offer.PolicyTo;
            ProductCode = offer.ProductCode;
            PolicyStatus = PolicyStatus.Active;
            PolicyHolder = offer.PolicyHolder;
            TotalPremium = offer.TotalPrice;
            Covers = offer.Covers.Select(x => new PolicyCover(x)).ToList();
        }

        public string PolicyNumber { get; set; }

        public string VersionNumber { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public DateTime VersionFrom { get; set; }

        public DateTime VersionTo { get; set; }

        public string ProductCode { get; set; }

        public PolicyStatus PolicyStatus { get; set; }

        public PolicyHolder PolicyHolder { get; set; }

        public decimal TotalPremium { get; set; }

        public Policy Policy { get; set; }

        public IList<PolicyCover> Covers { get; set; }

        private string GetVersionNumber(int number)
        {
            return $"VERSION_{number}";
        }
    }
}
