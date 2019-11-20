using PolicyService.Api.Enums;
using PolicyService.Bo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolicyService.Bo.Infrastructure.Database
{
    public static class SampleDataSeed
    {
        public static void InsertSampleData(PolicyDbContext dbContext)
        {
            if (!dbContext.Offer.Any())
            {
                var sampleOffer1 = new Offer()
                {
                    OfferNumber = "SAMPLE_OFFER_1",
                    OfferStatus = OfferStatus.Active,
                    PolicyFrom = new DateTime(2019, 12, 1),
                    PolicyTo = new DateTime(2020, 12, 1),
                    PolicyHolder = new PolicyHolder()
                    {
                        FirstName = "Clark",
                        LastName = "Kent",
                        Pesel = "80010112345"
                    },
                    ProductCode = "GOLDEN_HEALTH",
                    TotalPrice = 240,
                    ValidTo = new DateTime(2019, 12, 31),
                    Covers = new List<OfferCover>() 
                    {
                        new OfferCover()
                        {
                            CoverCode = "COVER1",
                            CoverFrom = new DateTime(2019, 12, 1),
                            CoverTo = new DateTime(2020, 12, 1),
                            Price = 110
                        },
                        new OfferCover()
                        {
                            CoverCode = "COVER2",
                            CoverFrom = new DateTime(2019, 12, 1),
                            CoverTo = new DateTime(2020, 12, 1),
                            Price = 140
                        }
                    }
                };

                dbContext.Offer.Add(sampleOffer1);
                dbContext.SaveChanges();
            }

            if (!dbContext.Policy.Any())
            {
                var sampleOffer2 = new Offer()
                {
                    OfferNumber = "SAMPLE_OFFER_1",
                    OfferStatus = OfferStatus.Sold,
                    PolicyFrom = new DateTime(2019, 11, 1),
                    PolicyTo = new DateTime(2020, 11, 1),
                    PolicyHolder = new PolicyHolder()
                    {
                        FirstName = "Bruce",
                        LastName = "Wayne",
                        Pesel = "80010112345"
                    },
                    ProductCode = "GOLDEN_HEALTH",
                    TotalPrice = 240,
                    ValidTo = new DateTime(2019, 12, 31),
                    Covers = new List<OfferCover>()
                    { 
                        new OfferCover()
                        {
                            CoverCode = "COVER1",
                            CoverFrom = new DateTime(2019, 12, 1),
                            CoverTo = new DateTime(2020, 12, 1),
                            Price = 110,
                        },
                        new OfferCover()
                        {
                            CoverCode = "COVER2",
                            CoverFrom = new DateTime(2019, 12, 1),
                            CoverTo = new DateTime(2020, 12, 1),
                            Price = 130
                        }
                    }
                };

                var samplePolicy = sampleOffer2.ConvertToPolicy();

                dbContext.Offer.Add(sampleOffer2);
                dbContext.Policy.Add(samplePolicy);
                dbContext.SaveChanges();
            }
        }
    }
}
