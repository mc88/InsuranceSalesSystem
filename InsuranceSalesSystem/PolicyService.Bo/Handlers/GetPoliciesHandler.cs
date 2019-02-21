using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Bo.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PolicyService.Bo.Mappers;

namespace PolicyService.Bo.Handlers
{
    public class GetPoliciesHandler : IRequestHandler<GetPoliciesRequestDto, GetPoliciesResponseDto>
    {
        private readonly PolicyDbContext dbContext;

        public GetPoliciesHandler(PolicyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<GetPoliciesResponseDto> Handle(GetPoliciesRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: request validation

            var policies = dbContext.Policy.Include(x => x.PolicyVersions).ThenInclude(x => x.PolicyHolder).ToList();

            var versions = policies.Select(x => x.GetPolicyVersion(DateTime.Now));

            var response = new GetPoliciesResponseDto()
            {
                PolicyVersions = versions.Select(x => PolicyVersionMapper.MapPolicyVersionToPolicyVersionDto(x)).ToArray()
            };

            return Task.FromResult(response);
        }
    }
}
