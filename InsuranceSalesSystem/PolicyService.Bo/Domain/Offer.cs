using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Enums;
using System;
using System.Collections.Generic;

namespace PolicyService.Bo.Domain
{
    public class Offer : BaseEntity
    {
        private int OFFER_VALIDITY_IN_DAYS = 30;

        public Offer() { }

        public Offer(CreateOfferRequestDto request, decimal calculatedPrice)
        {
            OfferNumber = GenerateNumberForNewOffer();
            OfferStatus = OfferStatus.Active;
            PolicyFrom = request.PolicyFrom;
            PolicyTo = request.PolicyTo;
            PolicyHolder = new PolicyHolder(request.PolicyHolder);
            ProductCode = request.ProductCode;
            TotalPrice = calculatedPrice;
            ValidTo = DateTime.Now.AddDays(OFFER_VALIDITY_IN_DAYS);
        }

        public string OfferNumber { get; set; }

        public string ProductCode { get; set; }

        public PolicyHolder PolicyHolder { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public IList<OfferCover> Covers { get; set; }

        public Policy ConvertToPolicy()
        {
            //TODO: map policyVersion, creation policy should be in Policy domain
            return new Policy()
            {
                PolicyNumber = OfferNumber,
                PolicyVersions = null,
                ProductCode = ProductCode
            };
        }

        private string GenerateNumberForNewOffer()
        {
            throw new NotImplementedException();
        }
    }
}
