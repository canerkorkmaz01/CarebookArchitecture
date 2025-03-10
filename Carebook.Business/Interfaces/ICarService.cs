using Carebook.Common.ViewModels;


namespace Carebook.Business.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetCarHomeList();
    }
}
