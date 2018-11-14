using MediatR;
using PolicyService.Api.Dto.Responses;

namespace PolicyService.Api.Dto.Requests
{
    public class FindPolicyRequestDto : IRequest<FindPolicyResponseDto>
    {
    }
}
