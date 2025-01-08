
using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {

        private const string entityName = "Rezervasyon";
        private readonly IReservationService _reservationService;
        private readonly ICarDropdownList _carDropdownList;

        public ReservationController(IReservationService reservationService, ICarDropdownList carDropdownList)
        {
            _reservationService = reservationService;
            _carDropdownList = carDropdownList;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _reservationService.ReservationList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var reservation = await _carDropdownList.GetCarDropdownListAsync();
            var reservationSelectList = new SelectList(reservation, "Id", "CarName");
            ViewBag.Reservation = reservationSelectList;
            return View();
        }
    }
}
