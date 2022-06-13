using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4_MVC_Razor.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [MaxLength(50), MinLength(3)]
        public string BookName { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
