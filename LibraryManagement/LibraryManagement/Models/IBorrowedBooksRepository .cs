using System.Collections.Generic;

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
