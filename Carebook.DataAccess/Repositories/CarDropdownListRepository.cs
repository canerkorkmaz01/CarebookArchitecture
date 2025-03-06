using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class CarDropdownListRepository : ICarDropdownListRepository
    {
        private readonly AppDbContext _context;

        public CarDropdownListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetCarDropdownListAsync()
        {
            return  await _context.Cars.OrderBy(p => p.CarName).ToListAsync();
        }
      }
    }

