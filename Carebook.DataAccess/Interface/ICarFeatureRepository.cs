using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.DataAccess.Interface
{
    public interface ICarFeatureRepository
    {
        Task<List<SelectListItem>> GetEditCarFeaturesAsync();

        Task<List<SelectListItem>> GetCarFeaturesAsync();

        Task GetFeatureById(int id);
        Task<List<int>> GetFeatureIdsByCarIdAsync(int carId);
    }
}
