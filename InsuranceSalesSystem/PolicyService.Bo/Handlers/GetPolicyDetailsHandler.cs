﻿using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Api.Exceptions;
using PolicyService.Bo.Infrastructure.Database;
using PolicyService.Bo.Mappers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PolicyService.Bo.Handlers
{
    public class GetPolicyDetailsHandler : IRequestHandler<GetPolicyDetailsRequestDto, GetPolicyDetailsResponseDto>
    {
        private readonly PolicyDbContext dbContext;

        public GetPolicyDetailsHandler(PolicyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<GetPolicyDetailsResponseDto> Handle(GetPolicyDetailsRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                //TODO: request validation

                var policy = dbContext.Policy.FirstOrDefault(x => x.PolicyNumber == request.PolicyNumber);

                if (policy == null)
                {
                    throw new PolicyNotFoundException(policy.PolicyNumber);
                }

                var policyVersion = policy.GetPolicyVersion(request.PolicyStartDate);

                if (policyVersion == null)
                {
                    //TODO: maybe move this to GetPolicyVersion method in Policy domain ??
                    throw new PolicyVersionNotFoundException(policy.PolicyNumber, request.PolicyStartDate);
                }

                var response = new GetPolicyDetailsResponseDto()
                {
                    PolicyVersion = PolicyVersionMapper.MapPolicyVersionToPolicyVersionDto(policyVersion)
                };

                return Task.FromResult(response);
            }
            catch (Exception)
            {
                //TODO:
                throw;
            }
        }
    }
}
