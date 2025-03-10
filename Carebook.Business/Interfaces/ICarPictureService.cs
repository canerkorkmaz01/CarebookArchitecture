using Carebook.Common.ViewModels;

namespace Carebook.Business.Interfaces
{
    public interface ICarPictureService
    {
        Task <IEnumerable<CarPictureViewModel>> CarPictureAsync(int id);
    }
}
