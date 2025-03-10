using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class PricingCarService : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;

        public PricingCarService(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PricingViewModel>> GetAllPricingAsync()
        {
            var pricings = await _pricingRepository.GetAllPricingAsync();
            var viewModel = _mapper.Map<List<PricingViewModel>>(pricings);
            return viewModel;
        }

        public async Task<IEnumerable<CarViewModel>> GetPricingAsync()
        {
            var pricing = await _pricingRepository.GetPricingAsync();
            return _mapper.Map<List<CarViewModel>>(pricing);
        }
    }
}
