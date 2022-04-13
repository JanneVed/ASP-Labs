using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab_1_Entity_Framework.Models
{
    class Leave
    {
        [Key] public int LeaveId { get; set; }

        [Required, Column(TypeName = "date")] public DateTime StartDate { get; set; }
        [Column(TypeName = "date")] public DateTime? EndDate { get; set; }
        public DateTime DateOfRegister { get; set; }
        [Required] public string TypeOfLeave { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
