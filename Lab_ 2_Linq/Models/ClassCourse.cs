using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab__2_Linq.Models
{
    class ClassCourse
    {
        [Key] public int ClassCourseId { get; set; }
        [Required, Column(TypeName = "date")] public DateTime StartDate { get; set; }
        [Required, Column(TypeName = "date")] public DateTime EndDate { get; set; }

        public int ClassId { get; set; }
        public int CourseId { get; set; }

        public SchoolClass SchoolClass { get; set; }
        public Course Course { get; set; }
    }
}
