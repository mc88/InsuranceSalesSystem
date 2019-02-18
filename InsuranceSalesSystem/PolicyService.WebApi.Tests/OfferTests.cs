using PolicyService.Api.Dto;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Web.Controllers;
using PolicyService.WebApi.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace PolicyService.WebApi.Tests
{
    public class OfferTests
    {
        private const string OfferControllerUrl = @"http://localhost:53182/api/Offer/";

        //[Fact]
        //public void CreateOffer()
        //{
        //    var url = $"{OfferControllerUrl}Create";

        //    var request = new CreateOfferRequestDto()
        //    {
        //        ProductCode = "GOLDEN_HEALTH",
        //        PolicyHolder = new PersonDto()
        //        {
        //            FirstName = "Clark",
        //            LastName = "Kent",
        //            Pesel = "81010112345"
        //        },
        //        SelectedCovers = new List<string>() { "COVER2", "COVER3" },
        //        PolicyFrom = new DateTime(2018, 12, 1),
        //        PolicyTo = new DateTime(2019, 12, 1)
        //    };



        //    var response = ApiClientHelper.Post<CreateOfferResponseDto>(url, request).Result;

        //    Assert.NotNull(response);
        //    Assert.NotNull(response.OfferNumber);
        //    Assert.Equal(DateTime.Now.AddDays(30).Date, response.OfferValidityEnd.Date);
        //    Assert.True(response.TotalPrice > 0);
        //}

        [Fact]
        public void CreateOffer()
        {
            var a = new OfferController(new MediatR.)
        }

    }
}
