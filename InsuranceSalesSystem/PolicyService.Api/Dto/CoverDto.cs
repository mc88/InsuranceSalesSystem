using System;

namespace PolicyService.Api.Dto
{
    public class CoverDto
    {
        public string CoverCode { get; set; }

        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }

        public decimal Price { get; set; }
    }
}
