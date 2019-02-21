using MediatR;
using PolicyService.Api.Dto.Responses;

namespace PolicyService.Api.Dto.Requests
{
    public class GetOffersRequestDto : IRequest<GetOffersResponseDto>
    {
        //TODO: in future there should be user name or id, or even more detailed properties for querying
    }
}
