using PolicyService.Api.Dto.Pricing.Responses;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicyService.Bo.Domain
{
    public class Offer : BaseEntity
    {
        private int OFFER_VALIDITY_IN_DAYS = 30;

        public Offer() { }

        public Offer(CreateOfferRequestDto request, CalculatePriceResponseDto calculatedPrice)
        {
            OfferNumber = GenerateNumberForNewOffer();
            OfferStatus = OfferStatus.Active;
            PolicyFrom = request.PolicyFrom;
            PolicyTo = request.PolicyTo;
            PolicyHolder = new PolicyHolder(request.PolicyHolder);
            ProductCode = request.ProductCode;
            TotalPrice = calculatedPrice.TotalPrice;
            ValidTo = DateTime.Now.AddDays(OFFER_VALIDITY_IN_DAYS);
            Covers = request.SelectedCovers.Select(x => 
                    new OfferCover(x, request.PolicyFrom, request.PolicyTo, calculatedPrice.CoverPrices[x]))
                .ToList();
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
            return new Policy(this);
        }

        private string GenerateNumberForNewOffer()
        {
            return $"OFF_{DateTime.Now.Ticks}";
        }
    }
}
