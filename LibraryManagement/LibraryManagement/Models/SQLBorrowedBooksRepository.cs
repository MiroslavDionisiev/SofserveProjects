﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace EmployeeManagement.Models
{
    public class SQLBorrowedBooksRepository : IBorrowedBooksRepository
    {
        private readonly AppDbContext context;
        public SQLBorrowedBooksRepository(AppDbContext context)
        {
            this.context = context;
        }
        public BorrowedBooks Add(BorrowedBooks book)
        {
            context.BorrowedBooks.Add(book);
            context.SaveChanges();
            return book;
        }

        public BorrowedBooks Delete(int id)
        {
            BorrowedBooks book = context.BorrowedBooks.Find(id);
            if(book != null)
            {
                context.BorrowedBooks.Remove(book);
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
            return book;
        }

        public BorrowedBooks GetBorrowedBook(int BorrowedId)
        {
            return context.BorrowedBooks.Find(BorrowedId);
        }

        public IEnumerable<BorrowedBooks> GetBorrowedBooks(string Id)
        {
            return context.BorrowedBooks.ToList().Where(book => book.UsersId == Id);
        }

        public BorrowedBooks Update(BorrowedBooks bookChange)
        {
            var book = context.BorrowedBooks.Attach(bookChange);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookChange;
        }

        public BorrowedBooks UserBorrowedBooks(int Id)
        {
            return context.BorrowedBooks.Find(Id);
        }
    }
}