using MediatR;
using PolicyService.Api.Dto.Responses;

namespace PolicyService.Api.Dto.Requests
{
    public class ConvertOfferRequestDto : IRequest<ConvertOfferResponseDto>
    {
        public string OfferNumber { get; set; }
    }
}
