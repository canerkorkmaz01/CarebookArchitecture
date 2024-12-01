using Carebook.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Components
{

    [ViewComponent(Name = "Footer")]
    public class FooterViewComponents : ViewComponent
    {
        private readonly AppDbContext context;

        public FooterViewComponents(AppDbContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = context.Contacts.SingleOrDefault(q => q.Enabled);
            return View(model);
        }
    }
}