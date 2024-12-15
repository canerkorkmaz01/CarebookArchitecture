using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class PricingRepository : IPricingRepository
    {
        private readonly AppDbContext _context;

        public PricingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pricing>> GetPricingAsync()
        {
            return await _context.Pricings.OrderBy(p => p.Cars).AsNoTracking().ToListAsync();
        }
    }
}
