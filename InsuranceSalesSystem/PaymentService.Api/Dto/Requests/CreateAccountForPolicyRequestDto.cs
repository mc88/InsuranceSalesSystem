using MediatR;
using PaymentService.Api.Dto.Responses;
using System;

namespace PaymentService.Api.Dto.Requests
{
    public class CreateAccountForPolicyRequestDto : IRequest<CreateAccountForPolicyResponseDto>
    {
        public string PolicyNumber { get; set; }

        public decimal Price { get; set; }

        public DateTime PolicyStartDate { get; set; }
    }
}
