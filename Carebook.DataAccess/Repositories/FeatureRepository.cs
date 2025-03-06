using Carebook.Common.ViewModels;
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

        public async Task<IEnumerable<Feature>> GetAllAsync()
        {
            return await _context.Features.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Feature>> GetAllNameAsync()
        {
            return await _context.Features
                 .Include(f => f.User)
                .OrderBy(x => x.Name).ToListAsync();
        }
    }
}
