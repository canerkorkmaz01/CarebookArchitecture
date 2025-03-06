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

        public async Task<IEnumerable<Pricing>> GetAllPricingAsync()
        {
            return await _context.Pricings
                .Include(p => p.Cars)
                .Include(p => p.User)
                .OrderBy(p => p.Cars.CarName)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetPricingAsync()
        {
            return await _context.Cars
                .Include(p=>p.Pricings)
                .OrderBy(x => x.CarName)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
