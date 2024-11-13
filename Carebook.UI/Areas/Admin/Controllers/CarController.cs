using Carebook.Business.Interfaces;
using Carebook.Business.Services;
using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators")]
    public class CarController : Controller
    {
        private readonly ICarFeatureService _carFeatureService;
        private readonly ICarPageListService _carPageListService;
        private readonly IService<FeatureViewModel> _Feature;

        public CarController(ICarPageListService carPageListService, ICarFeatureService carFeatureService, IService<FeatureViewModel> Feature)
        {
            _carPageListService = carPageListService;
            _carFeatureService = carFeatureService;
            _Feature= Feature;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            // Service üzerinden veriyi alıyoruz
            var model = await _carPageListService.GetPagedCarsAsync(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Feature= _Feature.GetAllAsync();
            ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
            return View();
        }
    }
}
