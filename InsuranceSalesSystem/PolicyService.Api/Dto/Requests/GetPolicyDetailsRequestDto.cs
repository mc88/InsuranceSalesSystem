using MediatR;
using PolicyService.Api.Dto.Responses;
using System;

namespace PolicyService.Api.Dto.Requests
{
    public class GetPolicyDetailsRequestDto : IRequest<GetPolicyDetailsResponseDto>
    {
        public string PolicyNumber { get; set; }

        public DateTime PolicyStartDate { get; set; }
    }
}
