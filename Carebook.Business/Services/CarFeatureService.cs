using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.Business.Services
{
    public class CarFeatureService : ICarFeatureService
    {
        private readonly ICarFeatureRepository _carFeatureRepository;
        private readonly IMapper _mapper;

        public CarFeatureService(ICarFeatureRepository carFeatureRepository, IMapper mapper)
        {
            _carFeatureRepository = carFeatureRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SelectListItem>> GetCarFeaturesAsync()
        {
            var features = await _carFeatureRepository.GetCarFeaturesAsync();

            var selectListItems = features.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            }).ToList();

            return selectListItems;
        }

        public async Task<IEnumerable<SelectListItem>> GetEditCarFeaturesAsync()
        {
            var features = await _carFeatureRepository.GetEditCarFeaturesAsync();

            var editfeatures = features.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name,
                Selected = features.Any(p => p.Id == f.Id)
            }).ToList();


            return editfeatures;
        }

        public async Task GetFeatureById(int id)
        {
            await _carFeatureRepository.GetFeatureById(id);
        }

        public async Task<IEnumerable<int>> GetCarFeatureIdsAsync(int carId)
        {
            var car = await _carFeatureRepository.GetFeatureIdsByCarIdAsync(carId);

            if (car == null)
                throw new Exception("Araç Bulunamadı");
            return car.Features.Select(f => f.Id).ToList();
        }
    }
}
