using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Api.Exceptions;
using PolicyService.Bo.Infrastructure.Database;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            try
            {
                //TODO: validate request

                var offer = dbContext.Offer.FirstOrDefault(x => x.OfferNumber == request.OfferNumber);

                if(offer == null)
                {
                    throw new OfferNotFoundException(request.OfferNumber);
                }

                var policy = offer.ConvertToPolicy();
                dbContext.Policy.Add(policy);
                dbContext.SaveChanges();

                var response = new ConvertOfferResponseDto()
                {
                    PolicyNumber = policy.PolicyNumber
                };

                return Task.FromResult(response);
            }
            catch (Exception)
            {

                //TODO:
                return Task.FromResult<ConvertOfferResponseDto>(null);
            }
        }
    }
}
