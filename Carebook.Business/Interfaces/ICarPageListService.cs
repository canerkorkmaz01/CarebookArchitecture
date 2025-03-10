using Carebook.Common.ViewModels;
using PagedList;

namespace Carebook.Business.Interfaces
{
    public interface ICarPageListService
    {
        Task<IPagedList<CarViewModel>> GetPagedCarsAsync(int pageNumber, int pageSize);
    }
}
