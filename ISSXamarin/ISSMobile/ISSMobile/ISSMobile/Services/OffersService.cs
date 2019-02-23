using ISSMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSMobile.Services
{
    public interface IOffersService
    {
        Task<List<Offer>> GetOffers();
        Task<bool> CreateOffer(CreateOffer offer);
    }

    public class OffersService : IOffersService
    {
        private readonly IRestService restService;

        public OffersService(IRestService restService)
        {
            this.restService = restService;
        }

        public async Task<List<Offer>> GetOffers()
        {
            try
            {
                var url = "Offer/GetAll";
                var response = await restService.Get<OffersDetails>(url);

                return response.Offers.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<bool> CreateOffer(CreateOffer offer)
        {
            try
            {
                var url = "Offer/Create";
                await restService.Post<object>(url, offer);

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
