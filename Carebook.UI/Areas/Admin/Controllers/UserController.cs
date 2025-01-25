using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
