using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab__2_Linq.Models
{
    class Teacher
    {
        [Key] public int TeacherId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string Lastname { get; set; }
        [Required] public string Adress { get; set; }
        public string? Email { get; set; }
        public string? WorkNumber { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
