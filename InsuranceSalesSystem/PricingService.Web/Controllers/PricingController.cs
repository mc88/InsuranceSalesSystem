using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PricingService.Api.Dto;
using System.Threading.Tasks;

namespace PricingService.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Pricing")]
    public class PricingController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<PricingController> logger;

        public PricingController(IMediator mediator, ILogger<PricingController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;

        }

        [HttpPost]
        public async Task<CalculatePriceResponseDto> CalculatePrice([FromBody] CalculatePriceRequestDto request)
        {
            logger.LogInformation($"Calculating price for product '{request?.ProductCode}' and covers: {string.Join(", ", request?.SelectedCovers)}");

            CalculatePriceResponseDto response = await mediator.Send(request);

            logger.LogInformation($"Calculated price {response?.TotalPrice}");

            return response;
        }
    }
}