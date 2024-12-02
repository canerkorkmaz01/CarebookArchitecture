using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
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

        public async Task CarPictureAsync(int id)
        {
            await _context.CarPictures.Where(q=>q.CarId ==id).ToListAsync();
        }
    }
}
