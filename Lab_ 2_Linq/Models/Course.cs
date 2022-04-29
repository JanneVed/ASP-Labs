using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab__2_Linq.Models
{
    public class Course
    {
        [Key] public int CourseId { get; set; }
        [Required] public string CourseName { get; set; }
        public int? Points { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
