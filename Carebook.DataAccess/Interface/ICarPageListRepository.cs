using Carebook.Common.ViewModels;
using PagedList;


namespace Carebook.DataAccess.Interface
{
    public interface ICarPageListRepository
    {
        Task<IPagedList<CarViewModel>> GetPagedCarsAsync(int pageNumber, int pageSize);
    }
}
