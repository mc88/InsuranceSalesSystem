using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Api.Exceptions;
using PolicyService.Bo.Infrastructure.Database;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PolicyService.Bo.Handlers
{
    public class ConvertOfferHandler : IRequestHandler<ConvertOfferRequestDto, ConvertOfferResponseDto>
    {
        private readonly PolicyDbContext dbContext;

        public ConvertOfferHandler(PolicyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ConvertOfferResponseDto> Handle(ConvertOfferRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: validate request

            var offer = dbContext.Offer.Include(x => x.Covers).Include(x => x.PolicyHolder).FirstOrDefault(x => x.OfferNumber == request.OfferNumber);

            if (offer == null)
            {
                throw new OfferNotFoundException(request.OfferNumber);
            }

            //TODO: check offer is not expired and status
            //TODO: check if there is no policy created for this offer

            var policy = offer.ConvertToPolicy();
            dbContext.Policy.Add(policy);
            dbContext.SaveChanges();

            var response = new ConvertOfferResponseDto()
            {
                PolicyNumber = policy.PolicyNumber
            };

            return Task.FromResult(response);
        }
    }
}
