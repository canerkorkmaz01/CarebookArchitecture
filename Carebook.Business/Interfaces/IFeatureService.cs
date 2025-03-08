using Carebook.Common.ViewModels;


namespace Carebook.Business.Interfaces
{
    public interface IFeatureService
    {
        Task<IEnumerable<FeatureViewModel>>GetAllNameFeatures();

        Task<IEnumerable<FeatureViewModel>> GetAllAsync();

    }
}
