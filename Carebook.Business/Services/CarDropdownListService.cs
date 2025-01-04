using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class CarDropdownListService : ICarDropdownListService
    {
        private readonly ICarDropdownList _carDropdownList;
        private readonly IMapper _mapper;

        public CarDropdownListService(ICarDropdownList carDropdownList, IMapper mapper)
        {
            _carDropdownList = carDropdownList;
            _mapper = mapper;   
        }

        public async Task<List<PricingViewModel>> GetCarDropdownlist()
        {
            var cars= await _carDropdownList.GetCarDropdownListAsync();
            return _mapper.Map<List<PricingViewModel>>(cars);
        }

      

    }
}
