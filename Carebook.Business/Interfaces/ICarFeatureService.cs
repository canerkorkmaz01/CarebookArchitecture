using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.Business.Interfaces
{
    public interface ICarFeatureService
    {
        Task<IEnumerable<SelectListItem>> GetEditCarFeaturesAsync();
        Task<IEnumerable<SelectListItem>> GetCarFeaturesAsync();

        Task GetFeatureById (int id);

        Task<IEnumerable<int>> GetCarFeatureIdsAsync(int carId);
    }
}
