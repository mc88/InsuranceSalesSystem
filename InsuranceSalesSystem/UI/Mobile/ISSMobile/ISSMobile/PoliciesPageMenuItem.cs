using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSMobile
{

    public class PoliciesPageMenuItem
    {
        public PoliciesPageMenuItem()
        {
            TargetType = typeof(PoliciesPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}