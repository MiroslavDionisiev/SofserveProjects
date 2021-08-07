using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IBorrowedBooksRepository _borrowedBooksRepository;
        private readonly IDeadlineRequestRepository _deadlineRequestRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IBorrowedBooksRepository _borrowedBooksRepository, IDeadlineRequestRepository _deadlineRequestRepository, UserManager<ApplicationUser> userManager)
        {
            this._borrowedBooksRepository = _borrowedBooksRepository;
            this._deadlineRequestRepository = _deadlineRequestRepository;
            this.userManager = userManager;
        }

        /// <summary>
        /// Returns the list of users's borrowed books
        /// </summary>
        [HttpGet]
        public IActionResult MyBooks()
        {
            var book = this._borrowedBooksRepository.GetUserBorrowedBooks(this.userManager.GetUserId(User));
            return View(book);
        }

        /// <summary>
        /// Sends request for prolonging the terms for the book return
        /// </summary>
        [HttpPost]
        public IActionResult MyBooks(int borrowedId)
        {
            if (ModelState.IsValid)
            {
                BorrowedBooks bookRequested = this._borrowedBooksRepository.GetBorrowedBook(borrowedId);
                // check if there is already sent pending request
                if (this._deadlineRequestRepository.IsBookOfUserRequested(bookRequested.BorrowedId) == false)
                {
                    DeadlineRequest request = new DeadlineRequest
                    {
                        BorrowedId = bookRequested.BorrowedId,
                        RequestStatus = Status.Pending
                    };

                    DeadlineRequest newRequest = this._deadlineRequestRepository.Add(request);
                    return RedirectToAction("requestsent", new { status = true });
                }
                else
                {
                    return RedirectToAction("requestsent", new { status = false });
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult RequestSent(bool status)
        {
            return View(status);
        }
    }
}
