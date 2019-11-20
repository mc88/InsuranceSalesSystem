using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public PolicyController(IMediator mediator, ILogger logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("{policyNumber}/{date}")]
        public async Task<GetPolicyDetailsResponseDto> Get(string policyNumber, DateTime date)
        {
            logger.LogInformation($"Searching for policy: {policyNumber}, date: {date} ...");

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
            logger.LogInformation($"Terminating policy: {request?.PolicyNumber}, date: {request?.TerminationDate} ...");

            TerminatePolicyResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}