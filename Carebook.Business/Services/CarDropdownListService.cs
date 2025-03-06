using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class CarDropdownListService : ICarDropdownListService
    {
        private readonly ICarDropdownListRepository _carDropdownList;
        private readonly IMapper _mapper;

        public CarDropdownListService(ICarDropdownListRepository carDropdownList, IMapper mapper)
        {
            _carDropdownList = carDropdownList;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<CarViewModel>> GetCarDropdownlist()
        {
            var cars= await _carDropdownList.GetCarDropdownListAsync();
            return _mapper.Map<List<CarViewModel>>(cars);
        }

      

    }
}
