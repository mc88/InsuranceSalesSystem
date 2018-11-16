using MediatR;
using PaymentService.Api.Dto.Responses;
using System;

namespace PaymentService.Api.Dto.Requests
{
    public class GetAccountDetailsRequestDto : IRequest<GetAccountDetailsResponseDto>
    {
        public string PolicyNumber { get; set; }

        public DateTime Date { get; set; }
    }
}
