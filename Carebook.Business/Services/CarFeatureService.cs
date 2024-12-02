using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.Business.Services
{
    public class CarFeatureService : ICarFeatureService
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CarFeatureService(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<SelectListItem>> GetCarFeaturesAsync()
        {
            return await _carFeatureRepository.GetCarFeaturesAsync();
        }

        public async Task<List<SelectListItem>> GetEditCarFeaturesAsync()
        {
            return await _carFeatureRepository.GetEditCarFeaturesAsync();
        }

        public async Task GetFeatureById(int id)
        {
            await _carFeatureRepository.GetFeatureById(id);
        }
    }
}
