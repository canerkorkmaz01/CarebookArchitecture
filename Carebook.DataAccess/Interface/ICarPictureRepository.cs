using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface ICarPictureRepository
    {
        Task <List<CarPicture>> CarPictureAsync(int id);
        
    }
}
