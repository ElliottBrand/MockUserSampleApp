using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace MockUsersSampleApp.Interfaces
{
    public interface IManageUsers
    {
        List<IdentityUser> GetUsers();
    }

    public class ManageUsers : IManageUsers
    {
        private UserManager<IdentityUser> _userManager;
        public ManageUsers(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public List<IdentityUser> GetUsers() => _userManager.Users.ToList();
    }
}
