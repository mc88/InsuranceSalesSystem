using MediatR;
using PaymentService.Api.Dto.Responses;

namespace PaymentService.Api.Dto.Requests
{
    public class ImportFileRequestDto : IRequest<ImportFileResponseDto>
    {
        public string PathToFile { get; set; }
    }
}
