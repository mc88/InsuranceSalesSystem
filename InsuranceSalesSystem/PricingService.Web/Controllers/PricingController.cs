using MediatR;
using Microsoft.AspNetCore.Mvc;
using PricingService.Api.Dto;
using System.Threading.Tasks;

namespace PricingService.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Pricing")]
    public class PricingController : Controller
    {
        private readonly IMediator mediator;

        public PricingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<string> Test()
        {
            return await Task.FromResult("Test success");
        }

        [HttpPost]
        public async Task<CalculatePriceResponseDto> CalculatePrice([FromBody] CalculatePriceRequestDto request)
        {
            CalculatePriceResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}