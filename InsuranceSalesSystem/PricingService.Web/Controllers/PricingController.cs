using MediatR;
using Microsoft.AspNetCore.Mvc;
using PricingService.Api.Dto;
using System.Collections.Generic;
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

        [HttpGet("TestDb")]
        public async Task<CalculatePriceResponseDto> TestDb()
        {
            var request = new CalculatePriceRequestDto()
            {
                PolicyHolderAge = 25,
                PolicyStartDate = new System.DateTime(2018, 12, 1),
                ProductCode = "GOLDEN_HEALTH",
                SelectedCovers = new List<string>() { "COVER1", "COVER2" }
            };

            CalculatePriceResponseDto response = await mediator.Send(request);

            return response;
        }


        [HttpPost]
        public async Task<CalculatePriceResponseDto> CalculatePrice([FromBody] CalculatePriceRequestDto request)
        {
            CalculatePriceResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}