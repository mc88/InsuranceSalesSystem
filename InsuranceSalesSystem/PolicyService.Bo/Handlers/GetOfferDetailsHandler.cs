using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Api.Exceptions;
using PolicyService.Bo.Infrastructure.Database;
using PolicyService.Bo.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PolicyService.Bo.Handlers
{
    public class GetOfferDetailsHandler : IRequestHandler<GetOfferDetailsRequestDto, GetOfferDetailsResponseDto>
    {
        private readonly PolicyDbContext dbContext;
        private readonly ILogger<GetOfferDetailsHandler> logger;

        public GetOfferDetailsHandler(PolicyDbContext dbContext, ILogger<GetOfferDetailsHandler> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Task<GetOfferDetailsResponseDto> Handle(GetOfferDetailsRequestDto request, CancellationToken cancellationToken)
        {
            var offer = dbContext.Offer.Include(x => x.Covers).Include(x => x.PolicyHolder).FirstOrDefault(x => x.OfferNumber == request.OfferNumber);

            if (offer == null)
            {
                logger.LogError($"Offer with number {request?.OfferNumber} not found");
                throw new OfferNotFoundException(request.OfferNumber);
            }

            logger.LogInformation($"Offer with number {request?.OfferNumber} found");

            var response = new GetOfferDetailsResponseDto()
            {
                Offer = OfferMapper.MapOfferToOfferDto(offer)
            };

            return Task.FromResult(response);
        }
    }
}
