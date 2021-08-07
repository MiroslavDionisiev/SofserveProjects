using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowedBooksRepository _borrowedBooksRepository;
        private readonly IDeadlineRequestRepository _deadlineRequestRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(IBookRepository bookRepository, IBorrowedBooksRepository _borrowedBooksRepository, IDeadlineRequestRepository _deadlineRequestRepository, UserManager<ApplicationUser> userManager)
        {
            this._bookRepository = bookRepository;
            this._borrowedBooksRepository = _borrowedBooksRepository;
            this._deadlineRequestRepository = _deadlineRequestRepository;
            this.userManager = userManager;
        }

        /// <summary>
        /// checks if the passes userid, first name and last name are coherent
        /// </summary>
        private async Task<bool> UserValidation(TransferViewModel transfer)
        {
            var user = await this.userManager.FindByIdAsync(transfer.UserId);
            if (user == null || user.FirstName != transfer.FirstName || user.LastName != transfer.LastName)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// redirect to view for creating a book view
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// adds the data for a new book to the database
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(BookCreateViewModel bookCreated)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    Name = bookCreated.Name,
                    Author = bookCreated.Author,
                    Genre = bookCreated.Genre,
                    Language = bookCreated.Language,
                    Description = bookCreated.Description,
                    Published = bookCreated.Published,
                    FreeCopies = bookCreated.Copies,
                    Copies = bookCreated.Copies
                };
                Book newBook = this._bookRepository.Add(book);
                return RedirectToAction("Details", "Home", new { id = newBook.Id });
            }
            return View();
        }


        /// <summary>
        /// redirect to view for edit book data view
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            // finds book by id
            Book book = this._bookRepository.GetBook(id);
            // redirects to page not found if the id of the route doesn't match a books
            if (book == null)
            {
                Response.StatusCode = 404;
                return View("PageNotFound");
            }
            BookEditViewModel bookEditViewModel = new BookEditViewModel
            {
                OldNumberOfCopies = book.Copies,
                CurrentBook = book
            };
            return View(bookEditViewModel);
        }

        /// <summary>
        /// applies changes made to book data and updates the database
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(BookEditViewModel book)
        {
            if (ModelState.IsValid)
            {
                if (book.OldNumberOfCopies != book.CurrentBook.Copies)
                {
                    if (book.OldNumberOfCopies > book.CurrentBook.Copies)
                    {
                        // distract from free copies the difference of Old overall number of copies and the new one, as there may be books to members
                        book.CurrentBook.FreeCopies -= book.OldNumberOfCopies - book.CurrentBook.Copies;
                        if (book.CurrentBook.FreeCopies < 0)
                        {
                            // if free copies become negative assign 0
                            book.CurrentBook.FreeCopies = 0;
                        }
                        // correct the number of overall copies if it is not in coherence with the number of borrowed copies 
                        book.CurrentBook.Copies = book.CurrentBook.FreeCopies + this._borrowedBooksRepository.GetNumberOfBorrowedBooks(book.CurrentBook.Id);
                    }
                    else
                    {
                        // assign the difference between the new overall copies and the number of borrowed books  
                        book.CurrentBook.FreeCopies = book.CurrentBook.Copies - this._borrowedBooksRepository.GetNumberOfBorrowedBooks(book.CurrentBook.Id);
                    }
                }
                Book newBook = this._bookRepository.Update(book.CurrentBook);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// redirects to view asking whether the admin wants to delete a book or not only if all the copies are at the library
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            if (book.FreeCopies == book.Copies)
            {
                return View(book);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// redirects in accordance to the clicked button
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            if (book == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Book newBook = this._bookRepository.Delete(book.Id);
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// redirects to view with form for transfering the book only if there are free copies
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Transfer(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            if (book.FreeCopies == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// upgrade the database according to the filled data
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Transfer(int id, TransferViewModel transfer)
        {
            if (ModelState.IsValid)
            {
                bool isUserValid = await this.UserValidation(transfer);

                if (isUserValid == true)
                {
                    // update the database storing the library books
                    Book book = this._bookRepository.GetBook(id);
                    book.FreeCopies--;
                    Book newBook = this._bookRepository.Update(book);

                    // create a new borrowed book and add it to the database
                    BorrowedBooks borrowedBook = new BorrowedBooks
                    {
                        UsersId = transfer.UserId,
                        BookId = id,
                        Date = DateTime.Now.AddDays(30),
                        IsReturned = false
                    };
                    BorrowedBooks newBorrowedBook = this._borrowedBooksRepository.Add(borrowedBook);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // returns warning if the user data is not coherent
                    ModelState.AddModelError("Error", "Wrong personal data inputted");
                    return View();
                }
            }
            return View();
        }

        /// <summary>
        /// redirects to view with all pending user request for prolonging the terms for keeping a book
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RequestHandler()
        {
            return View(this._deadlineRequestRepository.GetPendingRequest());
        }

        /// <summary>
        /// processes the approved or declined requests
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RequestHandler(IEnumerable<DeadlineRequest> requests)
        {
            foreach (DeadlineRequest request in requests)
            {
                // for approved requests prolong the terms of keeping the book and update the database 
                if (request.RequestStatus.ToString() == "Approved" && request.IsDeleted == false)
                {
                    BorrowedBooks book = this._borrowedBooksRepository.GetBorrowedBook(request.BorrowedId);
                    book.Date = book.Date.AddDays(30);
                    BorrowedBooks newBook = this._borrowedBooksRepository.Update(book);
                }
                request.IsDeleted = true;
                this._deadlineRequestRepository.Update(request);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// redirects to view with form to fill when lirary receives a book
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Return()
        {
            return View();
        }

        /// <summary>
        /// processes the filled data and updates the databases according the returned book
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Return(BookReturnViewModel bookReturnViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isUserValid = await this.UserValidation(new TransferViewModel { UserId = bookReturnViewModel.UserId, FirstName = bookReturnViewModel.FirstName, LastName = bookReturnViewModel.LastName });

                if (isUserValid == true)
                {
                    Book book = this._bookRepository.GetBook(bookReturnViewModel.BookId);
                    // checks if the right book id is inputted 
                    if (book == null)
                    {
                        ModelState.AddModelError("Error", "Wrong book id");
                        return View();
                    }
                    BorrowedBooks borrowedBook = this._borrowedBooksRepository.GetUserBorrowedBooks(bookReturnViewModel.UserId).ToList().Find(book => book.BookId == bookReturnViewModel.BookId);
                    // checks if there is a borrowed book with certain id
                    if (borrowedBook == null)
                    {
                        ModelState.AddModelError("Error", "Data about borrowed book is not in coherence");
                        return View();
                    }
                    // changes the data of the objects and updates the database
                    book.FreeCopies++;
                    borrowedBook.IsReturned = true;
                    Book newBook = this._bookRepository.Update(book);
                    // sets pending requests for the borrowed book unprocessed when the book is returned to declined 
                    this._deadlineRequestRepository.RemovePendingRequestOfUserReturnedBook(borrowedBook.BorrowedId);
                    BorrowedBooks newBorrowedBook = this._borrowedBooksRepository.Update(borrowedBook);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Wrong personal data inputted");
                    return View();
                }
            }
            return View();
        }
    }
}
