using System;

namespace PolicyService.Api.Dto
{
    public class TerminatePolicyRequestDto
    {
        public string PolicyNumber { get; set; }

        public DateTime TerminationDate { get; set; }
    }
}
