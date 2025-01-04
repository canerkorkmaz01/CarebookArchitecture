using Carebook.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.DataAccess.Interface
{
    public interface ICarDropdownList
    {
        Task<List<Car>> GetCarDropdownListAsync();
    }
}
