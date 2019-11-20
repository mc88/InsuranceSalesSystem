using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Api.Exceptions;
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
    public class GetPolicyDetailsHandler : IRequestHandler<GetPolicyDetailsRequestDto, GetPolicyDetailsResponseDto>
    {
        private readonly PolicyDbContext dbContext;
        private readonly ILogger<GetPolicyDetailsHandler> logger;

        public GetPolicyDetailsHandler(PolicyDbContext dbContext, ILogger<GetPolicyDetailsHandler> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Task<GetPolicyDetailsResponseDto> Handle(GetPolicyDetailsRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: request validation

            var policy = dbContext.Policy.Include(x => x.PolicyVersions).ThenInclude(x => x.PolicyHolder).FirstOrDefault(x => x.PolicyNumber == request.PolicyNumber);

            if (policy == null)
            {
                logger.LogError($"Policy not found: {request?.PolicyNumber}");
                throw new PolicyNotFoundException(request.PolicyNumber);
            }

            logger.LogInformation($"Policy {request?.PolicyNumber} found");

            var policyVersion = policy.GetPolicyVersion(request.PolicyStartDate);

            if (policyVersion == null)
            {
                logger.LogError($"Policy version for policy {request?.PolicyNumber} and date {request?.PolicyStartDate} not found");
                //TODO: maybe move this to GetPolicyVersion method in Policy domain ??
                throw new PolicyVersionNotFoundException(policy.PolicyNumber, request.PolicyStartDate);
            }

            logger.LogInformation($"Policy version for policy {request?.PolicyNumber} and date {request?.PolicyStartDate} found, PolicyVersionId: {policyVersion.Id}");

            var response = new GetPolicyDetailsResponseDto()
            {
                PolicyVersion = PolicyVersionMapper.MapPolicyVersionToPolicyVersionDto(policyVersion)
            };

            return Task.FromResult(response);
        }
    }
}
