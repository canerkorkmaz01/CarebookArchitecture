using Carebook.Business.Interfaces;
using Carebook.Business.Services;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PricingController : Controller
    {
        private const string entityName = "Araç Fiyatlandırma";
        private readonly IPricingService _pricingRepository;
        private readonly ICarDropdownList _carDropdownList;
        private readonly IService<PricingViewModel> _carPricing;

        public PricingController(IPricingService pricingRepository, ICarDropdownList carDropdownList, IService<PricingViewModel> carPricing)
        {
            _pricingRepository = pricingRepository;
            _carDropdownList = carDropdownList;
            _carPricing = carPricing;
            _carPricing=carPricing; 
        }

        public async Task<IActionResult> Index()
        {
          
            var model = await _pricingRepository.GetPricingAsync();
                return View(model);
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {
            var Pricing = await _carDropdownList.GetCarDropdownListAsync();
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
    }
}
