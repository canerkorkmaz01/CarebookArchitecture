using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Carebook.UI.Controllers
{
    public class ReservationController : Controller
    {
        private const string entityName = "Rezervasyon";
        private readonly IReservationService _reservationList;
        private readonly IService<ReservationViewModel> _reservationService;
        public ReservationController(IReservationService reservationList, IService<ReservationViewModel> reservationService )
        {
            _reservationList = reservationList;
            _reservationService = reservationService;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(int id)
        {
            var reservation = await _reservationList.ReservationCarList();
            ViewBag.Reservation = new SelectList(reservation, "Id", "CarName");
            ViewBag.GearType = new SelectList(reservation, "Id", "GearType");
            ViewBag.FuelType = new SelectList(reservation, "Id", "FuelType");
            ViewBag.Photo = reservation.FirstOrDefault()?.Photo;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel reservation)
        {
            reservation.DateCreated = DateTime.Now;
            reservation.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            try
            {
                await _reservationService.AddAsync(reservation);
                TempData["success"] = $"{entityName} Ekleme işlemi başarıyla tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityName} Ekleme işleminde Hata Oluştu";
                return View(reservation);
            }
        }
    }
}
