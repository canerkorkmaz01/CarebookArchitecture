using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    internal interface IFeatureRepository
    {
        Task<List<Feature>> GetAllAsync();
    }
}
