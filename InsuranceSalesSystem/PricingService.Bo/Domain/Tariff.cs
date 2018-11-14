using System.Linq;
using System.Collections.Generic;
using PricingService.Api.Dto;
using PricingService.Api.Exceptions;

namespace PricingService.Bo.Domain
{
    public class Tariff : BaseEntity
    {
        //TODO rename to ProductCode and regenerate db migrations
        public string Code { get; set; }

        public virtual IList<TariffVersion> TariffVersions { get; set; }

        public PolicyPrice CalculatePolicyPrice(CalculatePriceRequestDto request)
        {
            var tariffVersion = TariffVersions.FirstOrDefault(x => x.CoverFrom <= request.PolicyStartDate && x.CoverTo >= request.PolicyStartDate);

            if (tariffVersion == null)
            {
                throw new NoValidTariffForProductAndDateException(request.ProductCode, request.PolicyStartDate);
            }

            var coverPrices = new List<CoverPrice>();


            foreach (var selectedCover in request.SelectedCovers)
            {
                var coverPrice = tariffVersion.GetCoverPrice(selectedCover, request.PolicyHolderAge);

                if (coverPrice == null)
                {
                    throw new NoPriceForGivenAgeException(selectedCover, request.PolicyHolderAge);
                }

                coverPrices.Add(coverPrice);
            }

            return new PolicyPrice(Code, coverPrices);
        }
    }
}
