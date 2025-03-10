using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Components
{

    [ViewComponent(Name = "Footer")]
    public class FooterViewComponents : ViewComponent
    {
        private readonly IContactService _context;

        public FooterViewComponents(IContactService context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _context.ContactList();
            
            return View(model);
        }
    }
}