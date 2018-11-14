using MediatR;
using PolicyService.Api.Dto.Responses;
using System;

namespace PolicyService.Api.Dto.Requests
{
    public class TerminatePolicyRequestDto : IRequest<TerminatePolicyResponseDto>
    {
        public string PolicyNumber { get; set; }

        public DateTime TerminationDate { get; set; }
    }
}
