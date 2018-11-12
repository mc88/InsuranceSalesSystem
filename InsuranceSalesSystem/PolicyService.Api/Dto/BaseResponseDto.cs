using System.Collections.Generic;

namespace PolicyService.Api.Dto
{
    public abstract class BaseResponseDto<T> where T : class
    {
        public int PageNumber { get; set; }

        public int RecordsPerPage { get; set; }

        public IList<T> Data { get; set; }
    }
}
