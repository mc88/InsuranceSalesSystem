using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Bo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using PolicyService.Bo.Mappers;

namespace PolicyService.Bo.Handlers
{
    public class GetOffersHandler : IRequestHandler<GetOffersRequestDto, GetOffersResponseDto>
    {
        private readonly PolicyDbContext dbContext;

        public GetOffersHandler(PolicyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<GetOffersResponseDto> Handle(GetOffersRequestDto request, CancellationToken cancellationToken)
        {
            var offers = dbContext.Offer.Include(x => x.Covers).Include(x => x.PolicyHolder).ToList().Select(x => OfferMapper.MapOfferToOfferDto(x));

            var response = new GetOffersResponseDto()
            {
                Offers = offers.ToArray()
            };

            return Task.FromResult(response);
        }
    }
}
