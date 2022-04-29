using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab__2_Linq.Models
{
    public class Student
    {
        [Key] public int StudentId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Address { get; set; }
        public string? Email { get; set; }
        public string? Number { get; set; }

        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))] public SchoolClass SchoolClass { get; set; }
    }
}
