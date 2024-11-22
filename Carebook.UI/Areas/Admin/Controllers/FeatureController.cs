using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {

        private const string entityName = "Araç Özelliği";
        private readonly ICarFeatureService _carFeatureService;
        private readonly ICarPageListService _carPageListService;
        private readonly IService<FeatureViewModel> _featureService;
        private readonly IService<CarViewModel> _carService;
        private readonly IFeatureService _featureServices;
        public FeatureController(ICarPageListService carPageListService, ICarFeatureService carFeatureService, 
            IService<FeatureViewModel> featureService, IService<CarViewModel> carService,IFeatureService featureServices)
        {
            _carPageListService = carPageListService;
            _carFeatureService = carFeatureService;
            _featureService = featureService;
            _carService = carService;
            _featureServices = featureServices;
        }
        public async Task<IActionResult> Index()
        {
            var feature = await _featureServices.GetAllNameFeatures();
            return View(feature);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeatureViewModel carFeature)
        {

            carFeature.DateCreated = DateTime.Now;
            carFeature.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Geçersiz veri girdiniz.";
                return View(carFeature);
            }

            try
            {
                // Service katmanını çağır
                await _featureService.AddAsync(carFeature);
                TempData["success"] = "Özellik başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata varsa logla
                Console.WriteLine($"Hata: {ex.Message}");
                TempData["error"] = "Bir hata oluştu.";
                return View(carFeature);
            }
        }



        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(FeatureViewModel carFeature)
        //{
        //    carFeature.DateCreated = DateTime.Now;
        //    carFeature.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _featureService.AddAsync(carFeature);
        //            TempData["success"] = $"{entityName} Ekleme işlemi başarıyla tamamlanmıştır";
        //            return RedirectToAction("Index");
        //        }
        //        catch (DbUpdateException)
        //        {
        //            TempData["error"] = $"{entityName} Eklem işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
        //            return View(carFeature);
        //        }
        //    }
        //    return View(carFeature);
        //}
    }
}
