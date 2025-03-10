using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Create(int reservationid)
        {
            var reservation = await _reservationList.ReservationCarList();
            var reservationCar =reservation.Where(c => c.Id == reservationid).ToList();

            ViewBag.Reservation = new SelectList(reservationCar, "Id", "CarName");
            ViewBag.GearType = new SelectList(reservationCar, "Id", "GearType");
            ViewBag.FuelType = new SelectList(reservationCar, "Id", "FuelType");
            ViewBag.Photo = reservationCar.FirstOrDefault()?.Photo;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel reservation)
        {
            reservation.DateCreated = DateTime.Now;
            reservation.UserId = 1;
            try
            {
                await _reservationService.AddAsync(reservation);
                return View();
                //return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            { 
                return View(reservation);
            }
        }
    }
}
