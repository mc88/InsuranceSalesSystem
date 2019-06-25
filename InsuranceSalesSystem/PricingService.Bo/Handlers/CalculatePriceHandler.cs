using MediatR;
using PricingService.Bo.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PricingService.Api.Dto;

namespace PricingService.Bo.Handlers
{
    public class CalculatePriceHandler : IRequestHandler<CalculatePriceRequestDto, CalculatePriceResponseDto>
    {
        private readonly PricingDbContext dbContext;

        public CalculatePriceHandler(PricingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<CalculatePriceResponseDto> Handle(CalculatePriceRequestDto request, CancellationToken cancellationToken)
        {
            var tariff = dbContext.Tariff
                .Include(x => x.TariffVersions)
                .ThenInclude(x => x.CoverPrices)
                .FirstOrDefault(x => x.Code == request.ProductCode);

            if (tariff == null)
            {
                Task.FromResult<CalculatePriceResponseDto>(null);
            }

            var policyPrice = tariff.CalculatePolicyPrice(request);
            
            var response = new CalculatePriceResponseDto
            {
                ProductCode = policyPrice.ProductCode,
                TotalPrice = policyPrice.TotalPrice,
                CoverPrices = policyPrice.SelectedCoverPrices.ToDictionary(x => x.Code, x => x.Price)
            };

            return Task.FromResult(response);
        }
    }
}
