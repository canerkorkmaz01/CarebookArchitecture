using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;


namespace Carebook.Business.Services
{
    public class CarHomeListService : ICarService
    {
        private readonly ICarHomeRepository _carHomeRepository;
        private readonly IMapper _mapper;

        public CarHomeListService(ICarHomeRepository carHomeRepository, IMapper mapper)
        {
            _carHomeRepository = carHomeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarViewModel>> GetCarHomeList()
        {
            var car = await _carHomeRepository.GetCarHome();
            return _mapper.Map<IEnumerable<CarViewModel>>(car);
        }

       
    }
}
