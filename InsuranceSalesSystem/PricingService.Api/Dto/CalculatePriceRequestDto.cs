using MediatR;
using System;
using System.Collections.Generic;

namespace PricingService.Api.Dto
{
    public class CalculatePriceRequestDto : IRequest<CalculatePriceResponseDto>
    {
        public string ProductCode { get; set; }

        public DateTime PolicyStartDate { get; set; }

        public int PolicyHolderAge { get; set; }

        public IList<string> SelectedCovers { get; set; }
    }
}
