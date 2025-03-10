using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators")]
    public class PricingController : Controller
    {
        private const string entityName = "Araç Fiyatlandırma";
        private readonly IPricingService _pricingRepository;
        private readonly ICarDropdownListService _carDropdownList;
        private readonly IService<PricingViewModel> _carPricing;

        public PricingController(IPricingService pricingRepository, ICarDropdownListService carDropdownList, IService<PricingViewModel> carPricing)
        {
            _pricingRepository = pricingRepository;
            _carDropdownList = carDropdownList;
            _carPricing=carPricing; 
        }

        public async Task<IActionResult> Index()
        {
            var model = await _pricingRepository.GetAllPricingAsync();
            return View(model);
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {
            var Pricing = await _carDropdownList.GetCarDropdownlist();
            var PricingSelectList = new SelectList(Pricing, "Id", "CarName");
            ViewBag.Pricing = PricingSelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PricingViewModel pricing)
        {
            pricing.DateCreated = DateTime.Now;
            pricing.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            try
            {
                await _carPricing.AddAsync(pricing);
                TempData["success"] = $"{entityName} Ekleme İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["success"] = $"{entityName} Ekleme işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
                return View(pricing);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Pricing = await _carDropdownList.GetCarDropdownlist();
            var PricingSelectList = new SelectList(Pricing, "Id", "CarName");
            ViewBag.Pricing = PricingSelectList;
            var model = await _carPricing.GetByIdAsync(id); 
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PricingViewModel pricing)
        {
            var Pricing = await _carDropdownList.GetCarDropdownlist();
            var PricingSelectList = new SelectList(Pricing, "Id", "CarName");
            ViewBag.Pricing = PricingSelectList;
            pricing.DateCreated = DateTime.Now;
            pricing.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            try
            {
                await _carPricing.Update(pricing);
                TempData["success"] = $"{entityName} Güncelleme İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["success"] = $"{entityName} Güncelleme işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
                return View(pricing);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var model =  await _carPricing.GetByIdAsync(id);
          
            try
            {
                await _carPricing.Remove(model);
                TempData["success"] = $"{entityName} Silme İşlemi başarıyla Tamamlanmıştır";
            }
            catch (DbUpdateException)
            {
                TempData["success"] = "isimli kayıt, bir ya da daha fazla kayıt ile ilişkili olduuğundan silme işlemi yapılamıyor!";

            }
            return RedirectToAction("Index");
        }
    }
}
