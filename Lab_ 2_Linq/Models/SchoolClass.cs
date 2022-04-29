using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab__2_Linq.Models
{
    public class SchoolClass
    {
        [Key] public int ClassId { get; set; }
        [Required] public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
