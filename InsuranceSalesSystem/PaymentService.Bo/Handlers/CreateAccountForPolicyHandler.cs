using MediatR;
using PaymentService.Api.Dto.Requests;
using PaymentService.Api.Dto.Responses;
using PaymentService.Api.Exceptions;
using PaymentService.Bo.Domain;
using PaymentService.Bo.Infrastructure.Database;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentService.Bo.Handlers
{
    public class CreateAccountForPolicyHandler : IRequestHandler<CreateAccountForPolicyRequestDto, CreateAccountForPolicyResponseDto>
    {
        private readonly PaymentDbContext dbContext;

        public CreateAccountForPolicyHandler(PaymentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<CreateAccountForPolicyResponseDto> Handle(CreateAccountForPolicyRequestDto request, CancellationToken cancellationToken)
        {
            var isAccountAlreadyExists = dbContext.PolicyAccount.Any(x => x.PolicyNumber == request.PolicyNumber);

            if (isAccountAlreadyExists)
            {
                throw new PolicyAccountAlreadyExists(request.PolicyNumber);
            }

            var policyAccount = new PolicyAccount(request);

            dbContext.PolicyAccount.Add(policyAccount);
            dbContext.SaveChanges();

            //TODO: should be something in response or maybe response is not need at all
            var response = new CreateAccountForPolicyResponseDto();

            return Task.FromResult(response);
        }
    }
}
