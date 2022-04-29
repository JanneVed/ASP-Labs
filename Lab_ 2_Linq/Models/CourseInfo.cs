using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab__2_Linq.Models
{
    public class CourseInfo
    {
        [Key] public int CourseTimespanId { get; set; }
        [Required, Column(TypeName = "date")] public DateTime StartDate { get; set; }
        [Required, Column(TypeName = "date")] public DateTime EndDate { get; set; }

        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))] public SchoolClass SchoolClass { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
