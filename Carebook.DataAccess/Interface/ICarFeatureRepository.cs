using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface ICarFeatureRepository
    {
        Task<IEnumerable<Feature>> GetEditCarFeaturesAsync();

        Task<IEnumerable<Feature>> GetCarFeaturesAsync();

        Task GetFeatureById(int id);
        Task<Car> GetFeatureIdsByCarIdAsync(int carId);
    }
}
