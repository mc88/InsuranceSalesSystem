using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentService.Api.Dto;
using PaymentService.Api.Dto.Requests;
using PaymentService.Api.Dto.Responses;
using PaymentService.Api.Exceptions;
using PaymentService.Bo.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentService.Bo.Handlers
{
    public class ImportFileHandler : IRequestHandler<ImportFileRequestDto, ImportFileResponseDto>
    {
        private readonly PaymentDbContext dbContext;

        public ImportFileHandler(PaymentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ImportFileResponseDto> Handle(ImportFileRequestDto request, CancellationToken cancellationToken)
        {
            var bankStatements = ReadFile(request.PathToFile);
            var affectedPolicies = bankStatements.Select(x => x.PolicyNumber).Distinct().ToList();

            var policyAccounts = dbContext.PolicyAccount.Include(x => x.AccountOperations)
                .Where(x => affectedPolicies.Contains(x.PolicyNumber))
                .ToList();

            foreach (var bankStatement in bankStatements)
            {
                var policyAccount = policyAccounts.FirstOrDefault(x => x.PolicyNumber == bankStatement.PolicyNumber);

                if (policyAccount == null)
                {
                    throw new PolicyAccountNotFoundException(bankStatement.PolicyNumber);
                }

                policyAccount.Apply(bankStatement);
            }

            dbContext.SaveChanges();

            var response = new ImportFileResponseDto();

            return Task.FromResult(response);
        }

        private IList<BankStatementDto> ReadFile(string pathToFile)
        {
            if (string.IsNullOrEmpty(pathToFile))
            {
                throw new BankStatementFileIsNotUploadedCorrectlyException();
            }

            var xml = XDocument.Load(pathToFile);

            var query = from x in xml.Root.Descendants("payment")
                        select new BankStatementDto()
                        {
                            PolicyNumber = x.Element("policyNumber").ToString(),
                            Amount = decimal.Parse(x.Element("amount").ToString()),
                            Date = DateTime.Parse(x.Element("date").ToString())
                        };

            return query.ToList();
        }
    }
}
