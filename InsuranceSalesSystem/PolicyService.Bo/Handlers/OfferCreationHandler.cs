using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Bo.Domain;
using PolicyService.Bo.Infrastructure.Database;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PolicyService.Bo.Handlers
{
    public class OfferCreationHandler : IRequestHandler<CreateOfferRequestDto, CreateOfferResponseDto>
    {
        private readonly PolicyDbContext dbContext;

        public OfferCreationHandler(PolicyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<CreateOfferResponseDto> Handle(CreateOfferRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: add request validtion 

            //TODO: get price from PricingService
            decimal price = 0;

            var offer = new Offer(request, price);

            dbContext.Offer.Add(offer);

            dbContext.SaveChanges();

            var response = new CreateOfferResponseDto()
            {
                OfferNumber = offer.OfferNumber,
                OfferValidityEnd = offer.ValidTo,
                TotalPrice = price
            };

            return Task.FromResult(response);
        }
    }
}
