using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public interface IBookRepository
    {
        Book GetBook(int Id);
        IEnumerable<Book> GetAllBooks();
        Book Add(Book book);
        Book Update(Book bookChange);
        Book Delete(int Id);
    }
}
