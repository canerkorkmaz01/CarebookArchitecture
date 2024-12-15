using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PricingController : Controller
    {
        private const string entityName = "Araç Fiyatlandırma";
        private readonly IPricingService _pricingRepository;
        private readonly ICarDropdownList _carDropdownList;

        public PricingController(IPricingService pricingRepository, ICarDropdownList carDropdownList)
        {
            _pricingRepository = pricingRepository;
            _carDropdownList = carDropdownList;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _pricingRepository.GetPricingAsync();
            return View(model);
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {
            ViewBag.Pricing = await _carDropdownList.GetCarDropdownListAsync();
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(PricingViewModel pricing)
        //{
        //    ViewBag.Pricing = await _carDropdownList.GetCarDropdownListAsync();
        //    return View();
        //}
    }
}
