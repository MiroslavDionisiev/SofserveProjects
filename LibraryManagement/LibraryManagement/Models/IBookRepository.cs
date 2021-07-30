using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
