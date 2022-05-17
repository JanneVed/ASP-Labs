using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_API_ClassLibrary
{
    public class Interest
    {
        public int InterestId { get; set; }
        public string MyInterest { get; set; }
        public string Description { get; set; }

        public ICollection<InterestInfo> InterestInfos { get; set; }
    }
}
