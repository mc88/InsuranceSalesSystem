using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentService.Api.Dto;
using PaymentService.Api.Dto.Requests;
using PaymentService.Api.Dto.Responses;
using PaymentService.Api.Exceptions;
using PaymentService.Bo.Infrastructure.Database;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentService.Bo.Handlers
{
    public class GetAccountDetailsHandler : IRequestHandler<GetAccountDetailsRequestDto, GetAccountDetailsResponseDto>
    {
        private readonly PaymentDbContext dbContext;

        public GetAccountDetailsHandler(PaymentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<GetAccountDetailsResponseDto> Handle(GetAccountDetailsRequestDto request, CancellationToken cancellationToken)
        {
            var policyAccount = dbContext.PolicyAccount.Include(x => x.AccountOperations).FirstOrDefault(x => x.PolicyNumber == request.PolicyNumber);

            if (policyAccount == null)
            {
                throw new PolicyAccountNotFoundException(request.PolicyNumber);
            }

            var response = new GetAccountDetailsResponseDto()
            {
                Account = new AccountDto()
                {
                    PolicyNumber = policyAccount.PolicyNumber,
                    CurrentBalance = policyAccount.BalanceAt(request.Date)
                }
            };

            return Task.FromResult(response);            
        }
    }
}
