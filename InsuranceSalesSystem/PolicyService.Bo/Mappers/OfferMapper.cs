using PolicyService.Api.Dto;
using PolicyService.Bo.Domain;
using System.Linq;

namespace PolicyService.Bo.Mappers
{
    public static class OfferMapper
    {
        public static OfferDto MapOfferToOfferDto(Offer offer)
        {
            return new OfferDto()
            {
                Covers = offer.Covers.ToDictionary(x => x.CoverCode, x => x.Price),
                OfferNumber = offer.OfferNumber,
                OfferStatus = offer.OfferStatus,
                PolicyFrom = offer.PolicyFrom,
                PolicyHolder = PolicyHolderMapper.MapPolicyHolderToPersonDto(offer.PolicyHolder),
                PolicyTo = offer.PolicyTo,
                ProductCode = offer.ProductCode,
                TotalPrice = offer.TotalPrice,
                ValidTo = offer.ValidTo
            };
        }
    }
}
