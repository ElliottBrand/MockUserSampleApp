using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MockUsersSampleApp.Controllers;
using MockUsersSampleApp.Interfaces;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace MockUsersSampleAppTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void HomeController_UsersList_ViewData_NotNullTest()
        {
            var mockManageUsers = new Mock<IManageUsers>();
            // Note: Pulling fake user data from private methods down below
            mockManageUsers.Setup(p => p.GetUsers()).Returns(GetUsersListTestData());
            var controller = new HomeController(mockManageUsers.Object);

            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            ViewDataDictionary viewData = viewResult.ViewData;
            Assert.NotNull(viewData["userList"]);
        }

        private List<IdentityUser> GetUsersListTestData()
        {
            var users = new List<IdentityUser>();
            users.Add(GetUserTestData());
            return users;
        }

        private IdentityUser GetUserTestData()
        {
            var user = new IdentityUser()
            {
                Id = "1234",
                UserName = "user@test.com"
            };
            return user;
        }
    }
}
