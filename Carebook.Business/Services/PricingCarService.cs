using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;

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

        public async Task<List<PricingViewModel>> GetPricingAsync()
        {
            var pricings = await _pricingRepository.GetPricingAsync();
            var viewModel = _mapper.Map<List<PricingViewModel>>(pricings);
            return viewModel;
        }

    }
}
