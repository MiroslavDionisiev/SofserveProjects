using System;
using System.Collections.Generic;
using Xunit;
using LibraryManagement.Models;
using LibraryManagement.Controllers;
using LibraryManagement.ViewModel;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LibraryManagement_Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void MyBooks_ReturnsAViewResult_WhenANewRequestIsMade()
        {
            // Arrange
            BorrowedBooks book = new BorrowedBooks
            {
                BorrowedId = 1,
                BookId = 1,
                UsersId = "SomeString",
                Date = DateTime.Now,
                IsReturned = false
            };

            var expectedRedirectValues = new RouteValueDictionary
            {
                { "status", true}
            };

            var mockBorrowedRepoBooks = new Mock<IBorrowedBooksRepository>();
            mockBorrowedRepoBooks.Setup(repo => repo.GetBorrowedBook(1)).Returns(book);
            var mockDeadlineRepoBooks = new Mock<IDeadlineRequestRepository>();
            var mockStore = new Mock<IUserStore<ApplicationUser>>();
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(mockStore.Object, null, null, null, null, null, null, null, null);
            var controller = new UserController(mockBorrowedRepoBooks.Object, mockDeadlineRepoBooks.Object, mockUserManager.Object);

            // Act
            var result = controller.MyBooks(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("requestsent", result.ActionName);
            Assert.Equal(expectedRedirectValues, result.RouteValues);
        }
    }
}
