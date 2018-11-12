using System.Collections.Generic;

namespace PolicyService.Bo.Domain
{
    //TODO : Policy should inherit Offer according docs
    public class Policy : BaseEntity //: Offer
    {
        public string PolicyNumber { get; set; }

        public string ProductCode { get; set; }

        public IList<PolicyVersion> PolicyVersions { get; set; }
    }
}
