using PolicyService.Api.Enums;
using System;

namespace PolicyService.Api.Dto
{
    public class PolicyInfoDto
    {
        public string Number { get; set; }

        public string ProductCode { get; set; }

        public string PolicyHolder { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public PolicyStatus PolicyStatus { get; set; }

        public decimal TotalPremium { get; set; }
    }
}
