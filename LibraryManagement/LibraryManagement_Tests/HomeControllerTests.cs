using System;
using System.Collections.Generic;
using Xunit;
using LibraryManagement.Models;
using LibraryManagement.Controllers;
using LibraryManagement.ViewModel;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagement_Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfBookss()
        {
            // Arrange
            var mockRepoBooks = new Mock<IBookRepository>();
            mockRepoBooks.Setup(repo => repo.GetAllBooks()).Returns(GetTestBooks());
            var controller = new HomeController(mockRepoBooks.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Book>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void Details_ReturnsAViewResult_WhenABookIsSelected()
        {
            // Arrange
            var mockRepoBooks = new Mock<IBookRepository>();
            Book book = new Book()
            {
                Id = 1,
                Name = "Name1",
                Author = "Author1",
                Genre = Genres.Fiction,
                Language = Languages.Bulgarian,
                Description = "Description1",
                Published = 2000,
                FreeCopies = 1,
                Copies = 4
            };
            mockRepoBooks.Setup(repo => repo.GetBook(1)).Returns(book);
            var controller = new HomeController(mockRepoBooks.Object);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Details", result.ViewName);
            var viewModel = controller.ViewData.Model as HomeDetailsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal(1, viewModel.Book.Id);
            Assert.Equal("Book details", viewModel.PageTitle);
        }

        private IEnumerable<Book> GetTestBooks()
        {   
            return new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Name = "Name1",
                    Author = "Author1",
                    Genre = Genres.Fiction,
                    Language = Languages.Bulgarian,
                    Description = "Description1",
                    Published = 2000,
                    FreeCopies = 1,
                    Copies = 4
                },
                new Book()
                {
                    Id = 2,
                    Name = "Name2",
                    Author = "Author2",
                    Genre = Genres.Fiction,
                    Language = Languages.Bulgarian,
                    Description = "Description2",
                    Published = 2000,
                    FreeCopies = 1,
                    Copies = 4
                }
            };
        }
    }
}
