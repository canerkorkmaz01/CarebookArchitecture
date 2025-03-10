using Carebook.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators")]
    public class UserController : Controller
    {
        private readonly IUserListService _userList;

        public UserController(IUserListService userList)
        {
            _userList = userList;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userList.UserListServices();

          return View(user);
        }
    }
}
