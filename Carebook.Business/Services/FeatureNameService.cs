using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class FeatureNameService : IFeatureService
    {
        private readonly IFeatureRepository _featureService;
        private readonly IMapper _mapper;

        public FeatureNameService(IMapper mapper, IFeatureRepository featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }

        public async Task<IEnumerable<FeatureViewModel>> GetAllAsync()
        {
            var feature = await _featureService.GetAllAsync();
            var featureViewModel =_mapper.Map<List<FeatureViewModel>>(feature);
            return featureViewModel;
        }

        public async Task<IEnumerable<FeatureViewModel>> GetAllNameFeatures()
        {
            var feturesname = await _featureService.GetAllNameAsync();
            var featureViewModels = _mapper.Map<List<FeatureViewModel>>(feturesname); 
            return featureViewModels;

        }
    }
}
