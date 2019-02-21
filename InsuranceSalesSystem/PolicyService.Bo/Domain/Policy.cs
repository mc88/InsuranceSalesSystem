﻿using PolicyService.Api.Enums;
using PolicyService.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicyService.Bo.Domain
{
    public class Policy : BaseEntity
    {
        public Policy() { }

        public Policy(Offer offer)
        {
            //Offer = offer;
            PolicyNumber = offer.OfferNumber;
            ProductCode = offer.ProductCode;
            PolicyVersions = new List<PolicyVersion>() { new PolicyVersion(offer) };
        }

        public string PolicyNumber { get; set; }

        public string ProductCode { get; set; }

        //public Offer Offer { get; set; }

        public IList<PolicyVersion> PolicyVersions { get; set; }

        public PolicyVersion Terminate(DateTime date)
        {
            var policyVersion = this.GetPolicyVersion(date);

            if (policyVersion == null)
            {
                //TODO: maybe move this to GetPolicyVersion method in Policy domain ??
                throw new PolicyVersionNotFoundException(PolicyNumber, date);
            }

            policyVersion.PolicyStatus = PolicyStatus.Terminated;

            return policyVersion;
        }

        public PolicyVersion GetPolicyVersion(DateTime date)
        {
            return PolicyVersions.FirstOrDefault(x => x.PolicyFrom <= date && x.PolicyTo >= date);
        }
    }
}
