using MediatR;
using System;
using System.Collections.Generic;

namespace PricingService.Api.Dto.Queries
{
    public class PricingRequestQuery : IRequest<PricingResponseDto>
    {
        public string ProductCode { get; set; }

        public string Pesel { get; set; }

        public DateTime PolicyStartDate { get; set; }

        public IList<string> SelectedCovers { get; set; }
    }
}
