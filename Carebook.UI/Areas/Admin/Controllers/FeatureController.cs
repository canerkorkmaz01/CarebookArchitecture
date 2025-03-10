using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators")]
    public class FeatureController : Controller
    {

        private const string entityName = "Araç Özelliği";

        private readonly IService<FeatureViewModel> _featureService;
        private readonly IService<CarViewModel> _carService;
        private readonly IFeatureService _featureServices;
        public FeatureController(IService<FeatureViewModel> featureService, IService<CarViewModel> carService,IFeatureService featureServices)
        {
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
            carFeature.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Geçersiz veri girdiniz.";
                return View(carFeature);
            }

            try
            {
                await _featureService.AddAsync(carFeature);
                TempData["success"] = "Özellik başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                TempData["error"] = "Bir hata oluştu.";
                return View(carFeature);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                NotFound();
            }
            var features = await _featureService.GetByIdAsync(id,true);
            return View(features);
        }

        [HttpPost]
        public async Task<IActionResult>  Edit(FeatureViewModel carFeature)
        {
            carFeature.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            try
            {
                await _featureService.Update(carFeature);
                TempData["success"] = $"{entityName}Güncelleme İşlemi Başarıyla Tamamlanmıştır ";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {

                TempData["error"] = $"{entityName} Güncelleme işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
                return View(carFeature);
            }
        }

        public async Task <IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var features = await _featureService.GetByIdAsync(id, true);

            try
            {
                await _featureService.Remove(features);
                TempData["success"] = $" {entityName}Silme İşlemi Başarıyla Gerçekleştirilmiştir";

            }
            catch (DbUpdateException e)
            {
                TempData["success"] = $"{e} Silme işlemi Başarısız Olmuştur";
            }
            return RedirectToAction("Index");
        }

    }
}
