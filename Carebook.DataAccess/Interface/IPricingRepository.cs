using Carebook.Entities;


namespace Carebook.DataAccess.Interface
{
    public interface IPricingRepository
    {
        Task<List<Pricing>> GetPricingAsync();
    }
}
