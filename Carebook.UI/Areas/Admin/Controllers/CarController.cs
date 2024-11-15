using Carebook.Business.Interfaces;
using Carebook.Business.Services;
using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;


namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        //private const string entityName = "Araç Ekleme";
        private readonly ICarFeatureService _carFeatureService;
        private readonly ICarPageListService _carPageListService;
        private readonly IService<FeatureViewModel> _featureService;
        private readonly IService<CarViewModel> _carService;

        public CarController(ICarPageListService carPageListService, ICarFeatureService carFeatureService, IService<FeatureViewModel> featureService, IService<CarViewModel> carService)
        {
            _carPageListService = carPageListService;
            _carFeatureService = carFeatureService;
            _featureService = featureService;
            _carService = carService;
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
            ViewBag.Feature= _carService.GetAllAsync();
            ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel viewModel, IFormFile carPhoto)
        {
            // Resim kontrolü: JPEG formatı ve 600x600 boyutunda olmalı
            if (carPhoto != null)
            {
                // Resim formatı kontrolü
                if (carPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("carPhoto", "Resim JPEG formatında olmalıdır.");
                    return View(viewModel);
                }

                // Resim boyutu kontrolü (600x600)
                using (var image = Image.Load(carPhoto.OpenReadStream()))
                {
                    if (image.Width != 600 || image.Height != 600)
                    {
                        ModelState.AddModelError("carPhoto", "Resim 600x600 boyutlarında olmalıdır.");
                        return View(viewModel);
                    }

                    // Resmi byte array olarak kaydetme
                    using (var memoryStream = new MemoryStream())
                    {
                        await carPhoto.CopyToAsync(memoryStream);
                        viewModel.PhotoFiles = memoryStream.ToArray();
                    }
                }
            }

            // Geri kalan verileri carViewModel'e ekleyelim ve carService ile kaydedelim
            //var car = _mapper.Map<Car>(viewModel);
            await _carService.AddAsync(viewModel);

            return RedirectToAction("Index");  // Başka bir sayfaya yönlendirme
        }


    }
}
