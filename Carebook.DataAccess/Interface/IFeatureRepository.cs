using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<Feature>> GetAllAsync();
        Task<IEnumerable<Feature>> GetAllNameAsync();
    }
}
