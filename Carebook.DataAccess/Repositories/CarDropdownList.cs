using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class CarDropdownList : ICarDropdownList
    {
        private readonly AppDbContext _context;

        public CarDropdownList(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarDropdownListAsync()
        {
            return  await _context.Cars.OrderBy(p => p.CarName).ToListAsync();
        }
      }
    }

