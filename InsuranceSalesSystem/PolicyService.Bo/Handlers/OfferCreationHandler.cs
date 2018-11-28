using MediatR;
using PolicyService.Api.Dto.Pricing.Requests;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Bo.Domain;
using PolicyService.Bo.Infrastructure.Communication.REST;
using PolicyService.Bo.Infrastructure.Database;
using PolicyService.Bo.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PolicyService.Bo.Handlers
{
    public class OfferCreationHandler : IRequestHandler<CreateOfferRequestDto, CreateOfferResponseDto>
    {
        private readonly PolicyDbContext dbContext;
        private readonly PricingApiFacade pricingApiFacade;

        public OfferCreationHandler(PolicyDbContext dbContext, PricingApiFacade pricingApiFacade)
        {
            this.dbContext = dbContext;
            this.pricingApiFacade = pricingApiFacade;
        }

        public Task<CreateOfferResponseDto> Handle(CreateOfferRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: add request validtion 

            var calculatePriceRequest = new CalculatePriceRequestDto()
            {
                PolicyHolderAge = AgeUtils.CalculateAgeFromPesel(request.PolicyHolder.Pesel),
                PolicyStartDate = request.PolicyFrom,
                ProductCode = request.ProductCode,
                SelectedCovers = request.SelectedCovers
            };

            var calculatePriceResponse = pricingApiFacade.CalculatePrice(calculatePriceRequest);

            var offer = new Offer(request, calculatePriceResponse);

            dbContext.Offer.Add(offer);

            dbContext.SaveChanges();

            var response = new CreateOfferResponseDto()
            {
                OfferNumber = offer.OfferNumber,
                OfferValidityEnd = offer.ValidTo,
                TotalPrice = offer.TotalPrice
            };

            return Task.FromResult(response);
        }
    }
}
