using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicyService.Bo.Domain
{
    //TODO : Policy should inherit Offer according docs - if not inherit it should have association with Offer
    public class Policy : BaseEntity //: Offer
    {
        public Policy() { }

        public Policy(Offer offer)
        {
            PolicyNumber = offer.OfferNumber;
            ProductCode = offer.ProductCode;
            PolicyVersions = new List<PolicyVersion>() { new PolicyVersion(offer) };
        }

        public string PolicyNumber { get; set; }

        public string ProductCode { get; set; }

        public IList<PolicyVersion> PolicyVersions { get; set; }

        public PolicyVersion Terminate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public PolicyVersion GetPolicyVersion(DateTime date)
        {
            //TODO: make sure that this condition is ok
            return PolicyVersions.FirstOrDefault(x => x.PolicyFrom == date);
        }
    }
}
