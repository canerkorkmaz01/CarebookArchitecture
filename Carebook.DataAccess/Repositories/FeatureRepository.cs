using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _context;

        public FeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Feature>> GetAllAsync()
        {
            return await _context.Features.ToListAsync();
        }
    }
}
