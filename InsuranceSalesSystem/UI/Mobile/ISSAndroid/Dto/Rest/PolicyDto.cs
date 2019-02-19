using System;

namespace ISSAndroid.Dto.Rest
{
    public class PolicyDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}