using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface ICarPictureRepository
    {
        Task <IEnumerable<CarPicture>> CarPictureAsync(int id);
        
    }
}
