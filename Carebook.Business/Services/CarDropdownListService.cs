using AutoMapper;
using Carebook.Business.Interfaces;
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
            return await _carDropdownList.GetCarDropdownListAsync();
        }
    }
}
