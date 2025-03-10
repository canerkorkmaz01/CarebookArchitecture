using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly AppDbContext _context;
        public CarFeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feature>> GetCarFeaturesAsync()
        {
            return await _context.Features.OrderBy(f => f.Name).ToListAsync();
        }

        public async Task<IEnumerable<Feature>> GetEditCarFeaturesAsync()
        {
           return await _context.Features.ToListAsync();
           
        }


        public async Task<Car> GetFeatureIdsByCarIdAsync(int carId)
        {
            return await _context.Cars
            .Include(c => c.Features)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == carId); 
        }
       

        public async Task GetFeatureById(int id)
        {
          await _context.Features.FindAsync(id);
        }

       
    }
}
