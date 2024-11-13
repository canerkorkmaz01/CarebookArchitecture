using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.Business.Interfaces
{
    public interface ICarFeatureService
    {
        Task<List<SelectListItem>> GetCarFeaturesAsync();
    }
}
