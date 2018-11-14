using MediatR;
using Microsoft.AspNetCore.Mvc;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using System;
using System.Threading.Tasks;

namespace PolicyService.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Policy")]
    public class PolicyController : Controller
    {
        private readonly IMediator mediator;

        public PolicyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{policyNumber}/{date}")]
        public async Task<GetPolicyDetailsResponseDto> Get(string policyNumber, DateTime date)
        {
            GetPolicyDetailsRequestDto request = new GetPolicyDetailsRequestDto()
            {
                PolicyNumber = policyNumber,
                PolicyStartDate = date
            };

            GetPolicyDetailsResponseDto response = await mediator.Send(request);

            return response;
        }

        [HttpPost("Terminate")]
        public async Task<TerminatePolicyResponseDto> Terminate([FromBody] TerminatePolicyRequestDto request)
        {
            TerminatePolicyResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}