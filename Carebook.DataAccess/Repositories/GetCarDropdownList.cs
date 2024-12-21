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
            return (IEnumerable<SelectListItem>)await _context.Cars.OrderBy(p => p.CarName).ToListAsync();
            

        }
        }
    }

