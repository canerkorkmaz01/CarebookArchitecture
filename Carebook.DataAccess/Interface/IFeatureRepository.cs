using Carebook.Common.ViewModels;
using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetAllAsync();
        Task<List<Feature>> GetAllNameAsync();
    }
}
