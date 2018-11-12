using System;

namespace PolicyService.Api.Dto
{
    public class CovertDto
    {
        public string CovertCode { get; set; }

        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }

        public decimal Price { get; set; }
    }
}
