using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBorrowedBooksRepository
    {
        IEnumerable<BorrowedBooks> GetUserBorrowedBooks(string Id);
        BorrowedBooks GetBorrowedBook(int BorrowedId);
        int GetNumberOfBorrowedBooks(int BookId);
        BorrowedBooks Add(BorrowedBooks book);
        BorrowedBooks Update(BorrowedBooks bookChange);
        BorrowedBooks Delete(int Id);
    }
}
