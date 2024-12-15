using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class GetCarDropdownList : ICarDropdownList
    {
        private readonly AppDbContext _context;

        public GetCarDropdownList(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetCarDropdownListAsync()
        {
            var cars = await _context.Cars.OrderBy(p => p.CarName).ToListAsync();
            return cars.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = car.CarName
            });

        }
        }
    }

