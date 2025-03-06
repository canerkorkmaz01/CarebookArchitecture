using Carebook.Common.ViewModels;
using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<Feature>> GetAllAsync();
        Task<IEnumerable<Feature>> GetAllNameAsync();
    }
}
