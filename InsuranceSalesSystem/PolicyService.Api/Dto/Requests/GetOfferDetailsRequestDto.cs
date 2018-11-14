using MediatR;
using PolicyService.Api.Dto.Responses;

namespace PolicyService.Api.Dto.Requests
{
    public class GetOfferDetailsRequestDto : IRequest<GetOfferDetailsResponseDto>
    {
        public string OfferNumber { get; set; }
    }
}
