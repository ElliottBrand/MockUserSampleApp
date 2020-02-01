using Microsoft.AspNetCore.Mvc;
using MockUsersSampleApp.Interfaces;

namespace MockUsersSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManageUsers _manageUsers;

        public HomeController(IManageUsers manageUsers)
        {
            _manageUsers = manageUsers;
        }

        public IActionResult Index()
        {
            ViewData["userList"] = _manageUsers.GetUsers();
            return View();
        }
    }
}
