using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_API.Model
{
    public class Interest
    {
        public int InterestId { get; set; }
        public string InterestName { get; set; }
        public string InterestDesc { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
