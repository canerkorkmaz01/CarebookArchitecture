using Carebook.Common.ViewModels;

namespace Carebook.Business.Interfaces
{
    public interface ICarDropdownListService
    {
        Task<IEnumerable<CarViewModel>> GetCarDropdownlist();
    }
}
