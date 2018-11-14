using MediatR;
using PolicyService.Api.Dto.Responses;
using System;
using System.Collections.Generic;

namespace PolicyService.Api.Dto.Requests
{
    public class CreateOfferRequestDto : IRequest<CreateOfferResponseDto>
    {
        public string ProductCode { get; set; }

        public PersonDto PolicyHolder { get; set; }

        public IList<string> SelectedCovers { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }
    }
}
