using PolicyService.Api.Enums;
using System;
using System.Collections.Generic;

namespace PolicyService.Bo.Domain
{
    public class PolicyVersion : BaseEntity
    {
        public string PoicyNumber { get; set; }

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
    }
}
