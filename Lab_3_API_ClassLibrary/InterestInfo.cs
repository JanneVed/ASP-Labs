using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_API_ClassLibrary
{
    public class InterestInfo
    {
        public int InterestInfoId { get; set; }
        public string InterestLink { get; set; }

        public int InterestID { get; set; }
        public Interest Interest { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
