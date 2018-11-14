using PolicyService.Api.Enums;
using System;

namespace PolicyService.Api.Dto
{
    public class PolicyVersionDto
    {
        public string PolicyNumber { get; set; }

        public string VersionNumber { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public DateTime VersionFrom { get; set; }

        public DateTime VersionTo { get; set; }

        public string ProductCode { get; set; }

        public PolicyStatus PolicyStatus { get; set; }

        public PersonDto PolicyHolder { get; set; }

        public decimal TotalPremium { get; set; }
    }
}
