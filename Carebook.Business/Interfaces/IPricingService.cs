using Carebook.Common.ViewModels;
using Carebook.Entities;

namespace Carebook.Business.Interfaces
{
    public interface IPricingService
    {
        Task<List<PricingViewModel>> GetPricingAsync();
    }
}
