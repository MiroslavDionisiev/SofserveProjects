using System;
using System.Collections.Generic;
using Xunit;
using LibraryManagement.Models;
using LibraryManagement.Controllers;
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
            mockRepoBooks.Setup(repo => repo.GetAllBooks()).Returns(GetTestBooks());
            var controller = new HomeController(mockRepoBooks.Object);

            // Act
            var result = controller.Details(2);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Book>(viewResult.ViewData.Model);
            Assert.Equal(1, model.);
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
