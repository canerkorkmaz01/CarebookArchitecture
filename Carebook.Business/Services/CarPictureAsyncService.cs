using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class CarPictureAsyncService: ICarPictureService
    {
        private readonly ICarPictureRepository _carPictureService;

        public CarPictureAsyncService(ICarPictureRepository carPictureService)
        {
            _carPictureService = carPictureService;
        }

        public async Task CarPictureAsync(int id)
        {
          await _carPictureService.CarPictureAsync(id); 
        }
    }
}
