using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
