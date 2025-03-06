using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class CarPictureAsyncService: ICarPictureService
    {
        private readonly ICarPictureRepository _carPictureService;
        private readonly IMapper _mapper;

        public CarPictureAsyncService(ICarPictureRepository carPictureService, IMapper mapper)
        {
            _carPictureService = carPictureService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarPictureViewModel>> CarPictureAsync(int id)
        {
            var carPictures = await _carPictureService.CarPictureAsync(id);
            return _mapper.Map<List<CarPictureViewModel>>(carPictures);
        }

       
    }
}
