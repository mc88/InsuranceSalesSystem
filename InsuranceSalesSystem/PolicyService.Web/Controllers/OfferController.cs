using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;

namespace PolicyService.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Offer")]
    public class OfferController : Controller
    {
        private readonly IMediator mediator;

        public OfferController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{offerNumber}")]
        public async Task<GetOfferDetailsResponseDto> Get(string offerNumber)
        {
            GetOfferDetailsRequestDto request = new GetOfferDetailsRequestDto() { OfferNumber = offerNumber };
            GetOfferDetailsResponseDto response = await mediator.Send(request);

            return response;
        }

        [HttpPost("Create")]
        public async Task<CreateOfferResponseDto> Create([FromBody] CreateOfferRequestDto request)
        {
            CreateOfferResponseDto response = await mediator.Send(request);

            return response;
        }

        [HttpPost("ConvertToPolicy")]
        public async Task<ConvertOfferResponseDto> ConvertToPolicy([FromBody] ConvertOfferRequestDto request)
        {
            ConvertOfferResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}