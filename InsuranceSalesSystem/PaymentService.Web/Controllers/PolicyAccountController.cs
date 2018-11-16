using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Api.Dto.Requests;
using PaymentService.Api.Dto.Responses;

namespace PaymentService.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/PolicyAccount")]
    public class PolicyAccountController : Controller
    {
        private readonly IMediator mediator;
        private readonly IHostingEnvironment hostingEnvironment;

        public PolicyAccountController(IMediator mediator, IHostingEnvironment hostingEnvironment)
        {
            this.mediator = mediator;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{policyNumber}/{date}")]
        public async Task<GetAccountDetailsResponseDto> Get(string policyNumber, DateTime date)
        {
            GetAccountDetailsRequestDto request = new GetAccountDetailsRequestDto()
            {
                PolicyNumber = policyNumber,
                Date = date
            };

            GetAccountDetailsResponseDto response = await mediator.Send(request);

            return response;
        }

        [HttpPost("CreateAccount")]
        public async Task<CreateAccountForPolicyResponseDto> CreateAccount([FromBody] CreateAccountForPolicyRequestDto requestDto)
        {
            CreateAccountForPolicyResponseDto response = await mediator.Send(requestDto);

            return response;
        }

        [HttpPost("ImportBankStatementFile")]
        public async Task<ImportFileResponseDto> ImportBankStatementFile(IFormFile file)
        {
            string pathToFile = null;

            if (file != null)
            {
                var path = Path.Combine(hostingEnvironment.WebRootPath, "uploads");

                if (file.Length > 0)
                {
                    pathToFile = Path.Combine(path, file.FileName);
                    using (var fileStream = new FileStream(pathToFile, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            ImportFileRequestDto request = new ImportFileRequestDto()
            {
                PathToFile = pathToFile
            };

            ImportFileResponseDto response = await mediator.Send(request);

            return response;
        }
    }
}