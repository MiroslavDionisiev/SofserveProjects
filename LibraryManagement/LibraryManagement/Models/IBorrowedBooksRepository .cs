using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBorrowedBooksRepository
    {
        BorrowedBooks GetBorrowedBooks(int Id);
        BorrowedBooks Add(BorrowedBooks book);
        BorrowedBooks Update(BorrowedBooks bookChange);
        BorrowedBooks Delete(int Id);
    }
}
