using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface ICarDropdownListRepository
    {
        Task<IEnumerable<Car>> GetCarDropdownListAsync();
    }
}
