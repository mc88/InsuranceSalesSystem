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

namespace PolicyService.Bo.Handlers
{
    public class TerminatePolicyHandler : IRequestHandler<TerminatePolicyRequestDto, TerminatePolicyResponseDto>
    {
        private readonly PolicyDbContext dbContext;

        public TerminatePolicyHandler(PolicyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<TerminatePolicyResponseDto> Handle(TerminatePolicyRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: validate request

            var policy = dbContext.Policy.Include(x => x.PolicyVersions).ThenInclude(x => x.PolicyHolder).FirstOrDefault(x => x.PolicyNumber == request.PolicyNumber);
            var policyVersion = policy.Terminate(request.TerminationDate);

            dbContext.Policy.Update(policy);
            dbContext.SaveChanges();

            var response = new TerminatePolicyResponseDto()
            {
                TerminatedPolicyVersion = PolicyVersionMapper.MapPolicyVersionToPolicyVersionDto(policyVersion)
            };

            return Task.FromResult(response);
        }
    }
}
