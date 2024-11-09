using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Areas.Admin.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
