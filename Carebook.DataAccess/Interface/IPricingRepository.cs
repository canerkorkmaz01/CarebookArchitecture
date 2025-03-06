using Carebook.Entities;


namespace Carebook.DataAccess.Interface
{
    public interface IPricingRepository
    {
        Task<IEnumerable<Pricing>> GetAllPricingAsync();

        Task<IEnumerable<Car>> GetPricingAsync();
    }
}
