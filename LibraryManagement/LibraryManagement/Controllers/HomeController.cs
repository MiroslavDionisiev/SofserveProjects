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

        public HomeController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
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

        /// <summary>
        /// Returns Details page of the book if such exist otherwise page not found
        /// </summary>
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
    }
}
