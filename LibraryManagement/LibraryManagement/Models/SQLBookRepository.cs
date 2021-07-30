using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace EmployeeManagement.Models
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext context;
        public SQLBookRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Book Add(Book book)
        {
            book.FreeCopies = book.Copies;
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
            Book book = context.Books.Find(id);
            if(book != null)
            {
                context.Books.Remove(book);
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books;
        }

        public Book GetBook(int Id)
        {
            return context.Books.Find(Id);
        }

        public Book Update(Book bookChange)
        {
            var book = context.Books.Attach(bookChange);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookChange;
        }
    }
}
