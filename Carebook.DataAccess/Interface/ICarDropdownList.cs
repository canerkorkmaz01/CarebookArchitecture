using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.DataAccess.Interface
{
    public interface ICarDropdownList
    {
        Task<IEnumerable<SelectListItem>> GetCarDropdownListAsync();
    }
}
