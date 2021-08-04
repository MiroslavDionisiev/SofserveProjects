using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowedBooksRepository _borrowedBooksRepository;
        private readonly IDeadlineRequestRepository _deadlineRequestRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IBookRepository bookRepository, IBorrowedBooksRepository _borrowedBooksRepository, IDeadlineRequestRepository _deadlineRequestRepository, UserManager<ApplicationUser> userManager)
        {
            this._bookRepository = bookRepository;
            this._borrowedBooksRepository = _borrowedBooksRepository;
            this._deadlineRequestRepository = _deadlineRequestRepository;
            this.userManager = userManager;
        }

        private async Task<bool> UserValidation(TransferViewModel transfer)
        {
            var user = await this.userManager.FindByIdAsync(transfer.UserId);
            if (user == null)
            {
                return false;
            }
            var userData = from users in this.userManager.Users
                           where users.Id == transfer.UserId && users.FirstName == transfer.FirstName && users.LastName == transfer.LastName
                           select users;
            if(userData == null)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = this._bookRepository.GetAllBooks();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(int? id)
        {
            Book book = this._bookRepository.GetBook(id.Value);
            if(book == null)
            {
                Response.StatusCode = 404;
                return View("PageNotFound");
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                Book = book,
                PageTitle = "Book details"
            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

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
                return RedirectToAction("details", new { id = newBook.Id });
            }
            return View();
        }   

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            BookEditViewModel bookEditViewModel = new BookEditViewModel
            {
                OldNumberOfCopies = book.Copies,
                CurrentBook = book
            };
            return View(bookEditViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(BookEditViewModel book)
        {
            if (ModelState.IsValid)
            {
                if(book.OldNumberOfCopies != book.CurrentBook.Copies)
                {
                    if (book.OldNumberOfCopies > book.CurrentBook.Copies)
                    {
                        book.CurrentBook.FreeCopies -= book.OldNumberOfCopies - book.CurrentBook.Copies;
                        if (book.CurrentBook.FreeCopies < 0)
                        {
                            book.CurrentBook.FreeCopies = 0;
                        }
                        book.CurrentBook.Copies = book.CurrentBook.FreeCopies + this._borrowedBooksRepository.GetNumberOfBorrowedBooks(book.CurrentBook.Id);
                    }
                    else
                    {
                        book.CurrentBook.FreeCopies = book.CurrentBook.Copies - this._borrowedBooksRepository.GetNumberOfBorrowedBooks(book.CurrentBook.Id);
                    }
                }
                Book newBook = this._bookRepository.Update(book.CurrentBook);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            if(book == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                Book newBook = this._bookRepository.Delete(book.Id);
                return RedirectToAction("index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Transfer(int id)
        {
            Book book = this._bookRepository.GetBook(id);
            if(book.FreeCopies == 0)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Transfer(int id, TransferViewModel transfer)
        {
            if (ModelState.IsValid)
            {
                bool isUserValid = await this.UserValidation(transfer);
                
                if (isUserValid == true)
                {
                    Book book = this._bookRepository.GetBook(id);
                    book.FreeCopies--;
                    Book newBook = this._bookRepository.Update(book);

                    BorrowedBooks borrowedBook = new BorrowedBooks
                    {
                        UsersId = transfer.UserId,
                        BookId = id,
                        Date = DateTime.Now.AddDays(30),
                        IsReturned = false
                    };
                    BorrowedBooks newBorrowedBook = this._borrowedBooksRepository.Add(borrowedBook);

                    return RedirectToAction("index");
                }
                else 
                {
                    return RedirectToAction("transfer");
                }  
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RequestHandler()
        {
            return View(this._deadlineRequestRepository.GetPendingRequest());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RequestHandler(IEnumerable<DeadlineRequest> requests)
        {
            foreach(DeadlineRequest request in requests)
            {
                if(request.RequestStatus.ToString() == "Approved" && request.IsDeleted == false)
                {
                    BorrowedBooks book = this._borrowedBooksRepository.GetBorrowedBook(request.BorrowedId);
                    book.Date = book.Date.AddDays(30);
                    BorrowedBooks newBook = this._borrowedBooksRepository.Update(book);
                }
                request.IsDeleted = true;
                this._deadlineRequestRepository.Update(request);
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Return()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Return(BookReturnViewModel bookReturnViewModel)
        {

            if (ModelState.IsValid)
            {
                bool isUserValid = await this.UserValidation(new TransferViewModel { UserId = bookReturnViewModel.UserId, FirstName = bookReturnViewModel.FirstName, LastName = bookReturnViewModel.LastName});

                if (isUserValid == true)
                {
                    Book book = this._bookRepository.GetBook(bookReturnViewModel.BookId);
                    if (book == null)
                    {
                        return RedirectToAction("return");
                    }
                    BorrowedBooks borrowedBook = this._borrowedBooksRepository.GetUserBorrowedBooks(bookReturnViewModel.UserId)
                        .Where(book => book.BookId == bookReturnViewModel.BookId && book.IsReturned == false).First();
                    if (borrowedBook == null)
                    {
                        return RedirectToAction("return");
                    }
                    book.FreeCopies++;
                    borrowedBook.IsReturned = true;
                    Book newBook = this._bookRepository.Update(book);
                    BorrowedBooks newBorrowedBook = this._borrowedBooksRepository.Update(borrowedBook);

                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("return");
                }
            }
            return View();
        }
    }
}
