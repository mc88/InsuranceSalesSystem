using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Bo.Infrastructure.Database;
using PolicyService.Bo.Mappers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PolicyService.Bo.Handlers
{
    public class TerminatePolicyHandler : IRequestHandler<TerminatePolicyRequestDto, TerminatePolicyResponseDto>
    {
        private readonly PolicyDbContext dbContext;
        private readonly ILogger<TerminatePolicyHandler> logger;

        public TerminatePolicyHandler(PolicyDbContext dbContext, ILogger<TerminatePolicyHandler> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Task<TerminatePolicyResponseDto> Handle(TerminatePolicyRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: validate request
            logger.LogInformation($"Terminating policy: {request?.PolicyNumber}, date: {request?.TerminationDate}");

            var policy = dbContext.Policy.Include(x => x.PolicyVersions).ThenInclude(x => x.PolicyHolder).FirstOrDefault(x => x.PolicyNumber == request.PolicyNumber);
            var policyVersion = policy.Terminate(request.TerminationDate);

            dbContext.Policy.Update(policy);
            dbContext.SaveChanges();

            logger.LogInformation($"Policy terminated {request?.PolicyNumber}, date: {request?.TerminationDate}");

            var response = new TerminatePolicyResponseDto()
            {
                TerminatedPolicyVersion = PolicyVersionMapper.MapPolicyVersionToPolicyVersionDto(policyVersion)
            };

            return Task.FromResult(response);
        }
    }
}
