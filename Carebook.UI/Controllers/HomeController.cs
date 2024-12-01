using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<CarViewModel> _carService;
        private readonly ICarService _carServices;

        public HomeController(IService<CarViewModel> carService, ICarService carServices)
        {
            _carService = carService;
            _carServices = carServices;
        }

        public async Task<IActionResult> Index()
        {
            //var model = await _carServices.GetCarsAsync(a => a.CarName,query => query.OrderBy(carName => carName)); 
            //return View(model);

            var model = await _carServices.GetCarsAsync(
               car => new CarViewModel
               {
                   CarName = car.CarName,
                   Photo = car.Photo
               },
               query => query.OrderBy(carViewModel => carViewModel.CarName));

            return View(model);
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
