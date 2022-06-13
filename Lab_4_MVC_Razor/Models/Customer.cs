using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4_MVC_Razor.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(50), MinLength(3)]
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerEmail { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
