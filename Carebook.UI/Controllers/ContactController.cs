using Carebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var contact = await _contactService.ContacGetList();
            return View(contact);
        }
    }
}
