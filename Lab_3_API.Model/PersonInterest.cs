using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_API.Model
{
    public class PersonInterest
    {
        public int PersonInterestId { get; set; }
        public string InterestLink { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
