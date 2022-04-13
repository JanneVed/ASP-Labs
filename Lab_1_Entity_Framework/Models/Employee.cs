using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab_1_Entity_Framework.Models
{
    class Employee
    {
        [Key] public int EmployeeId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Email { get; set; }
        public string? WorkNumber { get; set; }

        public ICollection<Leave> Leaves { get; set; }
    }
}
