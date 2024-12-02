using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.Business.Interfaces
{
    public interface ICarFeatureService
    {
        Task<List<SelectListItem>> GetEditCarFeaturesAsync();
        Task<List<SelectListItem>> GetCarFeaturesAsync();

        Task GetFeatureById (int id);    
    }
}
