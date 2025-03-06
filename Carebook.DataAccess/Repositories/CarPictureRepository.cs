using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class CarPictureRepository : ICarPictureRepository
    {
        private readonly AppDbContext _context;
      
        public CarPictureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarPicture>> CarPictureAsync(int id)
        {
           return await _context.CarPictures.Where(q => q.CarId == id).ToListAsync();
        }
    }
}
