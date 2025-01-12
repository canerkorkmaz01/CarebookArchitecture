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
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {

        private const string entityName = "Rezervasyon";
        private readonly IReservationService _reservationList;
        private readonly ICarDropdownListService _carDropdownList;
        private readonly IService<ReservationViewModel> _reservationService;

        public ReservationController(IReservationService reservationList, ICarDropdownListService carDropdownList, IService<ReservationViewModel> reservationService)
        {
            _reservationList = reservationList;
            _carDropdownList = carDropdownList;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _reservationList.ReservationList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var reservation = await _carDropdownList.GetCarDropdownlist();
            var reservationSelectList = new SelectList(reservation, "Id", "CarName");
            ViewBag.Reservation = reservationSelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel reservation)
        {
            reservation.DateCreated = DateTime.Now;
            reservation.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            try
            {
                await _reservationService.AddAsync(reservation);
                TempData["success"] = $"{entityName} Ekleme işlemi başarıyla tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityName} Ekleme işleminde Hata Oluştu";
                var reservations = await _carDropdownList.GetCarDropdownlist();
                var reservationSelectList = new SelectList(reservations, "Id", "CarName");
                ViewBag.Reservation = reservationSelectList;
                return View(reservation);
            }
        }
    }
}
