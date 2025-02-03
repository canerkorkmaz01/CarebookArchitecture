using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private const string entityname = "Adres";
        private readonly IContactService _contactService;
        private readonly IService<ContactViewModel> _viewmodelService; 

        public ContactController(IContactService contactService, IService<ContactViewModel> viewmodelService)
        {
            _contactService = contactService;
            _viewmodelService = _viewmodelService;
        }

        public async Task<IActionResult> Index()
        {
            var contect = await _contactService.ContactList();
            return View(contect);
        }

        public async Task<IActionResult>  Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel contact)
        {
            contact.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            contact.DateCreated = DateTime.Now;
            try
            {
                _viewmodelService.AddAsync(contact);    
                TempData["success"] = $"{entityname} Adres Ekleme İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityname} Adres Ekleme İşlemi Hata Oluştu";
                return View(contact);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var contact = _viewmodelService.GetByIdAsync(id);
            return View(contact);
        }
    }
}
