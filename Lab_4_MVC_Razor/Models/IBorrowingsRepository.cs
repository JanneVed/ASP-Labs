using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4_MVC_Razor.Models
{
    public interface IBorrowingsRepository
    {
        public Borrowing Create(Borrowing borrowing);
        public void Delete(Borrowing borrowing);
        public Borrowing Update(Borrowing borrowing);

        public IEnumerable<Borrowing> GetAllBorrowings();
        public Borrowing GetSingleBorrowings(int borrowingId);
    }
}
