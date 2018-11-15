using PolicyService.Api.Dto.Pricing.Requests;
using PolicyService.Api.Dto.Pricing.Responses;

namespace PolicyService.Bo.Infrastructure.Communication.REST
{
    public class PricingApiFacade
    {
        private readonly ApiClient apiClient;

        public PricingApiFacade(string baseUrl)
        {
            apiClient = new ApiClient(baseUrl);
        }

        public CalculatePriceResponseDto CalculatePrice(CalculatePriceRequestDto request)
        {
            var response = apiClient.Post<CalculatePriceResponseDto>("Pricing", null, request);

            //TODO: maybe it should return Task<CalculatePriceResponseDto> or use async/await
            return response.Result;
        }
    }
}
