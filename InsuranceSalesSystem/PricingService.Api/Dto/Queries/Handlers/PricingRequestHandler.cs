using MediatR;
using PricingService.Bo.Infrastructure.Database;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using PricingService.Api.Exceptions;
using PricingService.Bo.Utils;
using Microsoft.EntityFrameworkCore;

namespace PricingService.Api.Dto.Queries.Handlers
{
    public class PricingRequestHandler : IRequestHandler<PricingRequestQuery, PricingResponseDto>
    {
        private readonly PricingDbContext dbContext;

        public PricingRequestHandler(PricingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        Task<PricingResponseDto> IRequestHandler<PricingRequestQuery, PricingResponseDto>.Handle(PricingRequestQuery request, CancellationToken cancellationToken)
        {
            int age = AgeUtils.CalculateAgeFromPesel(request.Pesel);

            //var policyPrice = dbContext.PolicyPrice
            //    .FirstOrDefault(x => x.ProductCode == request.ProductCode);

            //var coverPrice = dbContext.CoverPrice
            //    .Where(x => x.T 
            //            && x.AgeFrom >= request.PersonAge
            //            && x.AgeTo <= request.PersonAge
            //            && 
            //tariff.CalculatePolicyPrice(policyPrice);


            //TODO: this is not done according to UML and not optimized - should be refactored
            var tariff = dbContext.Tariff.Include(x => x.TariffVersions).ThenInclude(x => x.CoverPrices).FirstOrDefault(x => x.Code == request.ProductCode);

            var tariffVersion = tariff.TariffVersions.FirstOrDefault(x => x.CoverFrom <= request.PolicyStartDate && x.CoverTo >= request.PolicyStartDate);

            if (tariffVersion == null)
            {
                throw new NoValidTariffForProductAndDateException(request.ProductCode, request.PolicyStartDate);
            }

            var coverPrices = tariffVersion.CoverPrices.Where(x => x.AgeFrom <= age && x.AgeTo >= age && request.SelectedCovers.Contains(x.Code));

            if (!coverPrices.Select(x => x.Code).SequenceEqual(request.SelectedCovers))
            {
                throw new NoPriceForGivenAgeException(age);
            }
            
            var response = new PricingResponseDto
            {
                ProductCode = request.ProductCode,
                TotalPrice = coverPrices.Sum(x => x.Price),
                CoverPrices = coverPrices.ToDictionary(x => x.Code, x => x.Price)
            };

            return Task.FromResult(response);
        }
    }
}
