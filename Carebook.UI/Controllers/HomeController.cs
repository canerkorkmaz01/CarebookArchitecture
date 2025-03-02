using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carServices;

        public HomeController( ICarService carServices)
        {
            _carServices = carServices;
        }

        public async Task<IActionResult> Index()
        {
           var car = await _carServices.GetCarHomeList();     
            return View(car);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

    }
}
