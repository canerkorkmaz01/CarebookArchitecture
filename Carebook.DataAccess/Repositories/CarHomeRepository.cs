using Carebook.Common.ViewModels;
using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class CarHomeRepository: ICarHomeRepository
    {

        private readonly AppDbContext _context;

        public CarHomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetCarHome()
        {
            var car = await _context.Cars.OrderBy(x => x.CarName).ToListAsync();
            return car;
        }

    
    }
}
