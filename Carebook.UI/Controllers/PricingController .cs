using Carebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    public class PricingController : Controller
    {
        private readonly IPricingService _pricingRepository;

        public PricingController(IPricingService pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _pricingRepository.GetPricingAsync();
            return View(model);
        }
    }
}
