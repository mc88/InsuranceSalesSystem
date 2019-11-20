using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using Serilog;

namespace PolicyService.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Offer")]
    public class OfferController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<OfferController> logger;

        public OfferController(IMediator mediator, ILogger<OfferController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("{offerNumber}")]
        public async Task<GetOfferDetailsResponseDto> Get(string offerNumber)
        {
            logger.LogInformation($"Searching for offer: {offerNumber} ...");

            GetOfferDetailsRequestDto request = new GetOfferDetailsRequestDto() { OfferNumber = offerNumber };
            GetOfferDetailsResponseDto response = await mediator.Send(request);

            return response;
        }

        [HttpPost("Create")]
        public async Task<CreateOfferResponseDto> Create([FromBody] CreateOfferRequestDto request)
        {
            logger.LogInformation($"Creating offer ...");

            CreateOfferResponseDto response = await mediator.Send(request);

            return response;
        }

        [HttpPost("ConvertToPolicy")]
        public async Task<ConvertOfferResponseDto> ConvertToPolicy([FromBody] ConvertOfferRequestDto request)
        {
            logger.LogInformation($"Converting to policy, offer number: {request?.OfferNumber} ...");

            ConvertOfferResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}