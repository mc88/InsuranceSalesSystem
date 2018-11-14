using PricingService.Bo.Domain;
using System;

namespace PricingService.Bo.Infrastructure.Database
{
    public static class SeedData
    {
        public static Tariff[] Tariffs()
        {
            return new Tariff[]
            {
                new Tariff() { Id = 1, Code = "GOLDEN_HEALTH" }
            };
        }

        public static TariffVersion[] TariffVersions()
        {
            return new TariffVersion[]
            {
                new TariffVersion() { Id = 1, CoverFrom = new DateTime(2018, 1, 1), CoverTo = new DateTime(2018,12,31), TariffId = 1 },
                new TariffVersion() { Id = 2, CoverFrom = new DateTime(2019, 1, 1), CoverTo = new DateTime(2019,12,31), TariffId = 1 }
            };
        }

        public static CoverPrice[] CoverPrices()
        {
            return new CoverPrice[]
            {
                new CoverPrice() { Id = 1, Code = "COVER1", AgeFrom = 18, AgeTo = 28, Price = 100, TariffVersionId = 1 },
                new CoverPrice() { Id = 2, Code = "COVER1", AgeFrom = 29, AgeTo = 45, Price = 120, TariffVersionId = 1 },
                new CoverPrice() { Id = 3, Code = "COVER1", AgeFrom = 46, AgeTo = 65, Price = 150, TariffVersionId = 1 },
                new CoverPrice() { Id = 4, Code = "COVER2", AgeFrom = 18, AgeTo = 45, Price = 200, TariffVersionId = 1 },
                new CoverPrice() { Id = 5, Code = "COVER2", AgeFrom = 46, AgeTo = 65, Price = 300, TariffVersionId = 1 },
                new CoverPrice() { Id = 6, Code = "COVER3", AgeFrom = 18, AgeTo = 65, Price = 135, TariffVersionId = 1 },
                new CoverPrice() { Id = 7, Code = "COVER3", AgeFrom = 66, AgeTo = 999, Price = 300, TariffVersionId = 1 },

                new CoverPrice() { Id = 8, Code = "COVER1", AgeFrom = 18, AgeTo = 28, Price = 110, TariffVersionId = 2 },
                new CoverPrice() { Id = 9, Code = "COVER1", AgeFrom = 29, AgeTo = 45, Price = 130, TariffVersionId = 2 },
                new CoverPrice() { Id = 10, Code = "COVER1", AgeFrom = 46, AgeTo = 65, Price = 160, TariffVersionId = 2 },
                new CoverPrice() { Id = 11, Code = "COVER2", AgeFrom = 18, AgeTo = 45, Price = 210, TariffVersionId = 2 },
                new CoverPrice() { Id = 12, Code = "COVER2", AgeFrom = 46, AgeTo = 65, Price = 310, TariffVersionId = 2 },
                new CoverPrice() { Id = 13, Code = "COVER3", AgeFrom = 18, AgeTo = 65, Price = 145, TariffVersionId = 2 },
                new CoverPrice() { Id = 14, Code = "COVER3", AgeFrom = 66, AgeTo = 999, Price = 310, TariffVersionId = 2 }
            };
        }

    }
}
