using System;

namespace PolicyService.Api.Dto
{
    public class FindOfferRequestDto
    {
        public string NumberLike { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal PriceFrom { get; set; }

        public decimal PriceTo { get; set; }

        public string ProductCode { get; set; }

        public DateTime CreationDateFrom { get; set; }

        public DateTime CreationDateTo { get; set; }

        public int PageNumber { get; set; }

        public int RecordsPerPage { get; set; }
    }
}
