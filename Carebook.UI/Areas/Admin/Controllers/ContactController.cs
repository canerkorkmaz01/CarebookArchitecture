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
    public class ContactController : Controller
    {
        private const string entityname = "Adres";
        private readonly IContactService _contactService;
        private readonly IService<ContactViewModel> _viewmodelService; 

        public ContactController(IContactService contactService, IService<ContactViewModel> viewmodelService)
        {
            _contactService = contactService;
            _viewmodelService = viewmodelService;
        }

        public async Task<IActionResult> Index()
        {
            var contact = await _contactService.ContactList();
            return View(contact);
        }

        [HttpGet]
        public IActionResult  Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel contact)
        {
            contact.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            contact.DateCreated = DateTime.Now;

            try
            {
                await _viewmodelService.AddAsync(contact);    
                TempData["success"] = $"{entityname} Adres Ekleme İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = $"{entityname} Adres Ekleme İşlemi Hata Oluştu ";
                return View(contact);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _viewmodelService.GetByIdAsync(id);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactViewModel contact)
        {
            contact.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            contact.DateCreated = DateTime.Now;
            try
            {
                await _viewmodelService.Update(contact);
                TempData["success"] = $"{entityname} Adres Güncelleme İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityname} Adres Güncelleme İşlemi Hata Oluştu";
                return View(contact);
            }
        }
    }
}
