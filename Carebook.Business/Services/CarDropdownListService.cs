using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IEnumerable<SelectListItem>> GetCarDropdownlist()
        {
            var cars= await _carDropdownList.GetCarDropdownListAsync();
            var car = _mapper.Map<IEnumerable<CarViewModel>>(cars);

            return car.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = car.CarName
            }).ToList();
        }
    }
}
