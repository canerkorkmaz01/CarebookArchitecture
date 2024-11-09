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
            try
            {
                var model = context.Contacts.SingleOrDefault(q => q.Enabled);

                if (model == null)
                {
                    // Eğer model boş ise (örneğin, etkin bir Contact yoksa)
                    return Content("Aktif iletişim bilgisi bulunamadı.");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                // Hata mesajını loglama veya kullanıcıya dostça bir mesaj gösterme
                // Örneğin: Loglama işlemi burada yapılabilir
                Console.WriteLine(ex.Message); // veya bir log servisi kullanılabilir

                // Kullanıcıya hata mesajı veya boş bir içerik dönme
                return Content("Üzgünüz, iletişim bilgileri yüklenirken bir hata oluştu.");
            }
        }
    }
}