using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab_3_API_ClassLibrary
{
    public class Person
    {
        [Key] public int PersonId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<InterestInfo> InterestInfos { get; set; }
    }
}
