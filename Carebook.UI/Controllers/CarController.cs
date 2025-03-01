using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarDropdownListService _carList;
        private readonly ICarFeatureService _carFeatureService;
        private readonly IFeatureService _featureList;
        private readonly IService<FeatureViewModel> _featureService;
        private readonly IService<CarViewModel> _carService;
        private const string entityName = "";

        public CarController(ICarDropdownListService carList, ICarFeatureService carFeatureService, IFeatureService featureList,
            IService<CarViewModel> carService, IService<FeatureViewModel> featureService)
        {
            _carList = carList;
            _carFeatureService = carFeatureService;
            _featureList = featureList;
            _carService = carService;
            _featureService = featureService;
        }


        public async Task<IActionResult> Index()
        {
            var car = await _carList.GetCarDropdownlist();
            return View(car);
        }

        public async Task<IActionResult> Car()
        {
            var car = await _carList.GetCarDropdownlist();
            return View(car);
        }

        public async Task<IActionResult> CarDetails(int id)
        {
            var model = await _carService.GetByIdAsync(id);
            var features = await _featureList.GetAllAsync();
            ViewBag.CarFeatures = await _carFeatureService.GetEditCarFeaturesAsync();
            return View(model);
        }
    }
}
