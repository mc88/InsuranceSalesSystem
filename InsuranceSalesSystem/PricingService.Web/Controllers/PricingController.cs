using MediatR;
using Microsoft.AspNetCore.Mvc;
using PricingService.Api.Dto;
using PricingService.Api.Dto.Queries;
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

        //TODO: change to get
        [HttpPost]
        public async Task<PricingResponseDto> GetPrice([FromBody] PricingRequestDto request)
        {
            //TODO: add mappers
            var query = new PricingRequestQuery()
            {
               Pesel = request.PolicyHolder.Pesel,
               ProductCode = request.ProductCode,
               SelectedCovers = request.SelectedCovers,
               PolicyStartDate = request.PolicyStartDate
            };

            PricingResponseDto response = await mediator.Send(query);

            return response;
        }
    }
}