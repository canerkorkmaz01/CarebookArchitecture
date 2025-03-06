using Carebook.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.DataAccess.Interface
{
    public interface ICarDropdownListRepository
    {
        Task<IEnumerable<Car>> GetCarDropdownListAsync();
    }
}
