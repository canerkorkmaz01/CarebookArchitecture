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
    [Authorize(Roles = "Administrators,Staff")]
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
            
            //foreach (var reservation in model)
            //{
            //    Console.WriteLine($"CarName: {reservation.User.Name}");// sorun burada
            //    Console.WriteLine($"CarName: {reservation.Cars.CarName}");
            //}

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
                var reservations = await _carDropdownList.GetCarDropdownlist();
                var reservationSelectList = new SelectList(reservations, "Id", "CarName");
                ViewBag.Reservation = reservationSelectList;
                return View(reservation);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _carDropdownList.GetCarDropdownlist();
            var reservationSelectList = new SelectList(reservation, "Id", "CarName");
            ViewBag.Reservation = reservationSelectList;
            var model = await _reservationService.GetByIdAsync(id);   
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ReservationViewModel reservation)
        {
            reservation.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            reservation.DateCreated = DateTime.Now;
       
            try
            {
                await _reservationService.Update(reservation);
                TempData["success"] = $"{entityName} Güncelleme İşlemi Başarıyla Tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
                TempData["error"] = $"{entityName} Güncelleme İşlemi Başarısız Oldu";
                return View(reservation);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var model = await _reservationService.GetByIdAsync(id);
            try
            {
                await _reservationService.Remove(model);
                TempData["success"] = $"{entityName} Silme İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityName} Silme İşleminde Hata Oluştu";
                return View("Index");
            }

        }
    }
}
